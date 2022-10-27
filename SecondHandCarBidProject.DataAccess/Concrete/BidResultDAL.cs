using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.BidCorporation;
using SecondHandCarBidProject.Common.DTOs.BidResult;
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
    public class BidResultDAL : IBidResultDAL
    {
        private readonly DapperContext _context;

        public BidResultDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<BidResultAddPageDTO>> AddGet()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var bidOfferQuery = @"SELECT bo.Id as Id, (b.BidName + ' - ' + bu.Username + ' - ' + bo.OfferAmount) as Name
	                                    FROM BidOffer bo
	                                    JOIN Bid b on bo.BidId = b.Id
	                                    JOIN BaseUser bu on bo.BaseUserId = bo.BaseUserId
	                                    ORDER BY bo.CreatedDate DESC";
                    var bidOfferResult = await connection.QueryAsync<IdNameListDTO>(bidOfferQuery);
                    List<IdNameListDTO> bidOfferList = bidOfferResult.ToList();

                    BidResultAddPageDTO responseDTO = new BidResultAddPageDTO(bidOfferList);

                    return new ResponseModel<BidResultAddPageDTO>()
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

                return new ResponseModel<BidResultAddPageDTO>()
                {
                    Data = new BidResultAddPageDTO(new List<IdNameListDTO>()),
                    IsSuccess = false,
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> AddPost(BidResultAddSendDTO dto)
        {
            try
            {
                var query = "insert into BidResult(Id, BidOfferId, Explanation, CreatedBy) values(NEWID(), @bidOfferId, @explanation, @createdBy)";
                var parameters = new { bidOfferId = dto.BidOfferId, explanation = dto.Explanation, createdBy = dto.CreatedBy };
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

        public async Task<ResponseModel<bool>> Delete(Guid id, Guid modifiedBy)
        {
            try
            {
                var query = @"BEGIN TRAN
	                        BEGIN TRY
		                        DELETE FROM BidResult where Id = @id

		                        UPDATE BidResult SET ModifiedBy = @modifiedBy, ModifiedDate = GETDATE() where Id = @id

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

        public async Task<ResponseModel<BidResultListPageDTO>> List(int page = 1, int itemPerPage = 100)
        {
            try
            {
                var query = @"SELECT br.Id, b.BidName, bo.OfferAmount, bo.Explanation as OfferExplanation, bu.Username as OfferOwnerName, br.Explanation
	                        FROM BidResult br
	                        JOIN BidOffer bo on br.BidOfferId = bo.Id
	                        JOIN Bid b on bo.BidId = b.Id
	                        JOIN BaseUser bu on bo.BaseUserId = bu.Id
	                        WHERE br.IsActive = 1
	                        ORDER BY br.Id DESC
	                        OFFSET (@page - 1) * @itemPerPage ROWS FETCH NEXT @itemPerPage ROWS ONLY";
                var parameters = new { page = page, itemPerPage = itemPerPage };
                using (var connection = _context.CreateConnection())
                {
                    var bidResultResult = await connection.QueryAsync<BidResultListTableRowsDTO>(query, parameters);
                    List<BidResultListTableRowsDTO> bidResultList = bidResultResult.ToList();

                    int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM BidResult"));
                    maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);

                    BidResultListPageDTO responseDTO = new BidResultListPageDTO(bidResultList, maxPage);

                    return new ResponseModel<BidResultListPageDTO>()
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

                return new ResponseModel<BidResultListPageDTO>()
                {
                    Data = new BidResultListPageDTO(new List<BidResultListTableRowsDTO>(), 0),
                    IsSuccess = false,
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<BidResultUpdatePageDTO>> UpdateGet(Guid id)
        {
            try
            {
                var query = "SELECT Id, Explanation FROM BidResult WHERE Id = @id";
                var parameters = new { id = id };

                using (var connection = _context.CreateConnection())
                {
                    var responseDTO = connection.QueryFirstOrDefault<BidResultUpdatePageDTO>(query, parameters);

                    return new ResponseModel<BidResultUpdatePageDTO>()
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

                return new ResponseModel<BidResultUpdatePageDTO>()
                {
                    Data = new BidResultUpdatePageDTO(Guid.Empty, ""),
                    IsSuccess = false,
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> UpdatePost(BidResultUpdateSendDTO dto)
        {
            try
            {
                var query = "update BidResult set Explanation = @explanation, ModifiedBy = @modifiedBy, ModifiedDate = GETDATE() where Id = @id";
                var parameters = new {id = dto.Id, explanation = dto.Explanation, modifiedBy = dto.ModifiedBy};

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
    }
}
