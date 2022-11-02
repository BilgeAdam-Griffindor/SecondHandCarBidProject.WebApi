using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.CarBrand;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class CarBrandDAL : ICarBrandDAL
    {
        private readonly DapperContext _context;

        public CarBrandDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<bool>> AddPost(CarBrandAddDTO dto)
        {
            try
            {
                var query = "INSERT INTO CarBrand(BrandName) VALUES(@brandName)";
                var parameters = new { brandName = dto.BrandName };

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);

                    return new ResponseModel<bool>()
                    {
                        Data = result > 0,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<bool>()
                {
                    Data = false,
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> Delete(int brandId)
        {
            try
            {
                var query = "DELETE FROM CarBrand WHERE Id = @id";
                var parameters = new { id = brandId };

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);

                    return new ResponseModel<bool>()
                    {
                        Data = result > 0,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<bool>()
                {
                    Data = false,
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<CarBrandListPageDTO>> List(int page = 1, int itemPerPage = 100)
        {
            try
            {
                var query = @"SELECT Id, BrandName 
                    FROM CarBrand 
                    WHERE IsActive = 1 
                    ORDER BY BrandName 
                    OFFSET (@page - 1) * @itemPerPage ROWS FETCH NEXT @itemPerPage ROWS ONLY";
                var parameters = new { page = page, itemPerPage = itemPerPage };

                using (var connection = _context.CreateConnection())
                {
                    var carBrands = await connection.QueryAsync<CarBrandListTableRow>(query, parameters);
                    List<CarBrandListTableRow> carBrandsList = carBrands.ToList();

                    int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM CarBrand"));
                    maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);

                    CarBrandListPageDTO responseDTO = new CarBrandListPageDTO(carBrandsList, maxPage);

                    return new ResponseModel<CarBrandListPageDTO>()
                    {
                        Data = responseDTO,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<CarBrandListPageDTO>()
                {
                    Data = new CarBrandListPageDTO(new List<CarBrandListTableRow>(), 0),
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<CarBrandUpdatePageDTO>> UpdateGet(short id)
        {
            try
            {
                var query = "SELECT Id, BrandName as Name FROM CarBrand WHERE Id = @id";
                var parameters = new { id = id };

                using (var connection = _context.CreateConnection())
                {
                    var responseDTO = connection.QueryFirstOrDefault<CarBrandUpdatePageDTO>(query, parameters);

                    return new ResponseModel<CarBrandUpdatePageDTO>()
                    {
                        Data = responseDTO,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<CarBrandUpdatePageDTO>()
                {
                    Data = new CarBrandUpdatePageDTO(0, ""),
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> UpdatePost(CarBrandUpdateSendDTO dto)
        {
            try
            {
                var query = "UPDATE CarBrand SET BrandName = @brandName WHERE Id = @id";
                var parameters = new { brandName = dto.BrandName, id = dto.Id };

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);

                    return new ResponseModel<bool>()
                    {
                        Data = result > 0,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<bool>()
                {
                    Data = false,
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }
    }
}
