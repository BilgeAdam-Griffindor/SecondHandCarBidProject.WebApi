using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.BidCorporation;
using SecondHandCarBidProject.Common.DTOs.CarBuyAdditionalFee;
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
    public class CarBuyAdditionalFeeDAL : ICarBuyAdditionalFeeDAL
    {
        private readonly DapperContext _context;

        public CarBuyAdditionalFeeDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<CarBuyAdditionalFeeAddPageDTO>> AddGet()
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

                    var notaryQuery = "SELECT Id, (StartDate + ' - ' + EndDate + ': ' + FeeAmount + ' TL') as Name FROM NotaryFee";
                    var notaryResult = await connection.QueryAsync<IdNameListDTO>(notaryQuery);
                    List<IdNameListDTO> notaryList = notaryResult.ToList();

                    var commissionQuery = "SELECT Id, (StartDate + ' - ' + EndDate + '(' + MinPrice + 'TL - ' + MaxPrice  + 'TL):' + FeeAmount + ' TL') as Name FROM CommissionFee";
                    var commissionResult = await connection.QueryAsync<IdNameListDTO>(commissionQuery);
                    List<IdNameListDTO> commissionList = commissionResult.ToList();

                    CarBuyAdditionalFeeAddPageDTO responseDTO = new CarBuyAdditionalFeeAddPageDTO(carBuyList, notaryList, commissionList);

                    return new ResponseModel<CarBuyAdditionalFeeAddPageDTO>()
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

                return new ResponseModel<CarBuyAdditionalFeeAddPageDTO>()
                {
                    Data = new CarBuyAdditionalFeeAddPageDTO(new List<IdNameListDTO>(), new List<IdNameListDTO>(), new List<IdNameListDTO>()),
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> AddPost(CarBuyAdditionalFeeAddSendDTO dto)
        {
            try
            {
                var query = "INSERT INTO CarBuyAdditionalFee(Id, CarBuyId, NotaryFeeId, CommissionFeeId, CreatedBy) VALUES(NEWID(), @carBuyId, @notaryFeeId, @commissionFeeId, @createdBy)";
                var parameters = new { carBuyId = dto.CarBuyId, notaryFeeId = dto.NotaryFeeId, commissionFeeId = dto.CommissionFeeId, createdBy = dto.CreatedBy };
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

        public async Task<ResponseModel<bool>> Delete(Guid id, Guid modifiedBy)
        {
            try
            {
                var query = @"BEGIN TRAN
	                        BEGIN TRY
		                        DELETE FROM CarBuyAdditionalFee where Id = @id

		                        UPDATE CarBuyAdditionalFee SET ModifiedBy = @modifiedBy, ModifiedDate = GETDATE() where Id = @id

		                        COMMIT TRAN
	                        END TRY
	                        BEGIN CATCH
		                        ROLLBACK TRAN
		                        RAISERROR('İşlem Başarısız', 16, 1)
	                        END CATCH";
                var parameters = new { id = id, modifiedBy = modifiedBy };
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

        public async Task<ResponseModel<CarBuyAdditionalFeeListPageDTO>> List(int page = 1, int itemPerPage = 100)
        {
            try
            {
                var query = @"SELECT cbaf.Id , cBr.BrandName, cm.ModelName, cb.PreValuationPrice, cb.BidPrice, bu.Username, nf.FeeAmount, cf.FeeAmount, cbaf.CreatedDate
	                FROM CarBuyAdditionalFee cbaf
	                JOIN CarBuy cb on cbaf.CarBuyId = cb.Id
	                JOIN Car c on cb.CarId = c.Id
	                JOIN CarBrand cBr on c.CarBrandId = cBr.Id
	                JOIN CarModel cm on c.CarModelId = cm.Id
	                JOIN BaseUser bu on cb.CreatedBy = bu.Id
	                JOIN NotaryFee nf on cbaf.NotaryFeeId = nf.Id
	                JOIN CommissionFee cf on cbaf.CommissionFeeId = cf.Id
	                ORDER BY cbaf.CreatedDate DESC
	                OFFSET (@page - 1) * @itemPerPage ROWS FETCH NEXT @itemPerPage ROWS ONLY";
                var parameters = new { page = page, itemPerPage = itemPerPage };

                using (var connection = _context.CreateConnection())
                {
                    var carBuyAdditionalFeeResult = await connection.QueryAsync<CarBuyAdditionalFeeTableRowDTO>(query, parameters);
                    List<CarBuyAdditionalFeeTableRowDTO> carBuyAdditionalFeeList = carBuyAdditionalFeeResult.ToList();

                    int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM CarBuyAdditionalFee"));
                    maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);

                    CarBuyAdditionalFeeListPageDTO responseDTO = new CarBuyAdditionalFeeListPageDTO(carBuyAdditionalFeeList, maxPage);

                    return new ResponseModel<CarBuyAdditionalFeeListPageDTO>()
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

                return new ResponseModel<CarBuyAdditionalFeeListPageDTO>()
                {
                    Data = new CarBuyAdditionalFeeListPageDTO(new List<CarBuyAdditionalFeeTableRowDTO>(), 0),
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }
    }
}
