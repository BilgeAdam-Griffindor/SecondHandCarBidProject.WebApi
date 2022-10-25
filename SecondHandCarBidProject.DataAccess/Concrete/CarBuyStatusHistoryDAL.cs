using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.CarBuyStatusHistory;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class CarBuyStatusHistoryDAL : ICarBuyStatusHistoryDAL
    {
        private readonly DapperContext _context;
        public CarBuyStatusHistoryDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<CarBuyStatusHistoryAddPageDTO>> AddGet()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var carBuyQuery = @"SELECT cb.Id, (cbr.BrandName + ' - ' + cm.ModelName + ' - ' + bu.Username + ' - ' + cb.PreValuationPrice + 'TL - ' + cb.BidPrice + 'TL') as Name FROM CarBuy cb
	                    JOIN Car c on cb.CarId = c.Id
	                    JOIN CarBrand cBr on c.CarBrandId = cBr.Id
	                    JOIN CarModel cm on c.CarModelId = cm.Id
	                    JOIN BaseUser bu on cb.CreatedBy = bu.Id
	                    ORDER BY cb.CreatedDate DESC";
                    var carBuyResult = await connection.QueryAsync<IdNameListDTO>(carBuyQuery);
                    List<IdNameListDTO> carBuyList = carBuyResult.ToList();

                    var statusValueQuery = "SELECT Id, StatusName as Name FROM StatusValue WHERE StatusTypeId = 3";
                    var statusValueResult = await connection.QueryAsync<IdNameListDTO>(statusValueQuery);
                    List<IdNameListDTO> statusValueList = statusValueResult.ToList();

                    CarBuyStatusHistoryAddPageDTO responseDTO = new CarBuyStatusHistoryAddPageDTO(carBuyList, statusValueList);

                    return new ResponseModel<CarBuyStatusHistoryAddPageDTO>()
                    {
                        Data = responseDTO,
                        IsSuccess = true,
                        statusCode = Common.Validation.StatusCode.Success
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<CarBuyStatusHistoryAddPageDTO>()
                {
                    Data = new CarBuyStatusHistoryAddPageDTO(new List<IdNameListDTO>(), new List<IdNameListDTO>()),
                    IsSuccess = false,
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> AddPost(CarBuyStatusHistoryAddSendDTO dto)
        {
            try
            {
                var query = "INSERT INTO CarBuyStatusHistory(Id, CarBuyId, StatusValueId, CreatedBy) values(NEWID(), @carBuyId, @statusId, @createdBy)";
                var parameters = new {carBuyId = dto.CarBuyId, statusId = dto.StatusValueId, createdBy = dto.CreatedBy };
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);

                    return new ResponseModel<bool>()
                    {
                        Data = result > 0,
                        IsSuccess = true,
                        statusCode = Common.Validation.StatusCode.Success
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
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> Delete(Guid id)
        {
            try
            {
                var query = "DELETE FROM CarBuyStatusHistory WHERE Id = @id";
                var parameters = new { id = id };
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);

                    return new ResponseModel<bool>()
                    {
                        Data = result > 0,
                        IsSuccess = true,
                        statusCode = Common.Validation.StatusCode.Success
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
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<CarBuyStatusHistoryListPageDTO>> List(int page = 1, int itemPerPage = 100)
        {
            try
            {
                var query = @"SELECT cbsh.Id, cBr.BrandName, cm.ModelName, cb.PreValuationPrice, cb.BidPrice, sv.StatusName, bu.Username as CarOwner,  cbsh.Explanation, cbsh.CreatedDate 
                    FROM CarBuyStatusHistory cbsh 
                    JOIN CarBuy cb on cbsh.CarBuyId = cb.Id 
                    JOIN Car c on cb.CarId = c.Id JOIN CarBrand cBr on c.CarBrandId = cBr.Id 
                    JOIN CarModel cm on c.CarModelId = cm.Id 
                    JOIN BaseUser bu on c.CreatedBy = bu.Id 
                    JOIN StatusValue sv on cbsh.StatusValueId = sv.Id 
                    ORDER BY cbsh.CreatedDate DESC 
                    OFFSET (@page - 1) * @itemPerPage ROWS FETCH NEXT @itemPerPage ROWS ONLY ";
                var parameters = new { page = page, itemPerPage = itemPerPage };

                using (var connection = _context.CreateConnection())
                {
                    var carBuyStatusHistoryResult = await connection.QueryAsync<CarBuyStatusHistoryTableRow>(query, parameters);
                    List<CarBuyStatusHistoryTableRow> carBuyStatusHistoryList = carBuyStatusHistoryResult.ToList();

                    int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM CarBuyStatusHistory"));
                    maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);

                    CarBuyStatusHistoryListPageDTO responseDTO = new CarBuyStatusHistoryListPageDTO(carBuyStatusHistoryList, maxPage);

                    return new ResponseModel<CarBuyStatusHistoryListPageDTO>()
                    {
                        Data = responseDTO,
                        IsSuccess = true,
                        statusCode = Common.Validation.StatusCode.Success
                    };
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                    errors.Add(ex.InnerException.Message);

                return new ResponseModel<CarBuyStatusHistoryListPageDTO>()
                {
                    Data = new CarBuyStatusHistoryListPageDTO(new List<CarBuyStatusHistoryTableRow>(), 0),
                    IsSuccess = false,
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }
    }
}
