using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.BidOffer;
using SecondHandCarBidProject.Common.DTOs.BidResult;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class BidOfferDAL : IBidOfferDAL
    {
        private readonly DapperContext _context;

        public BidOfferDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<BidOfferAddPageDTO>> AddGet()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var baseUserQUery = @"SELECT Id, Username as Name from BaseUser ORDER BY Username";
                    var baseUserResult = await connection.QueryAsync<IdNameListDTO>(baseUserQUery);
                    List<IdNameListDTO> baseUserList = baseUserResult.ToList();

                    var bidQuery = @"SELECT Id, BidName as Name FROM Bid ORDER BY BidName";
                    var bidResult = await connection.QueryAsync<IdNameListDTO>(bidQuery);
                    List<IdNameListDTO> bidList = bidResult.ToList();

                    BidOfferAddPageDTO responseDTO = new BidOfferAddPageDTO(baseUserList, bidList);

                    return new ResponseModel<BidOfferAddPageDTO>()
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

                return new ResponseModel<BidOfferAddPageDTO>()
                {
                    Data = new BidOfferAddPageDTO(new List<IdNameListDTO>(), new List<IdNameListDTO>()),
                    IsSuccess = false,
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> AddPost(BidOfferAddSendDTO dto)
        {
            try
            {
                var query = "insert into BidOffer(Id, BaseUserId, BidId, OfferAmount, Explanation, CreatedBy) values (NEWID(), @baseUserId, @bidId, @offerAmount, @explanation, @createdBy)";
                var parameters = new { baseUserId = dto.BaseUserId, bidId = dto.BidId, offerAmount = dto.OfferAmount, explanation = dto.Explanation, createdBy = dto.CreatedBy };
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
		                    DELETE FROM BidOffer where Id = @id

		                    UPDATE BidOffer SET ModifiedBy = @modifiedBy, ModifiedDate = GETDATE() where Id = @id

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

        public async Task<ResponseModel<BidOfferListPageDTO>> List(int page = 1, int itemPerPage = 100)
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
                    var bidResultResult = await connection.QueryAsync<BidOfferListTableRowsDTO>(query, parameters);
                    List<BidOfferListTableRowsDTO> bidResultList = bidResultResult.ToList();

                    int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM BidOffer"));
                    maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);

                    BidOfferListPageDTO responseDTO = new BidOfferListPageDTO(bidResultList, maxPage);

                    return new ResponseModel<BidOfferListPageDTO>()
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

                return new ResponseModel<BidOfferListPageDTO>()
                {
                    Data = new BidOfferListPageDTO(new List<BidOfferListTableRowsDTO>(), 0),
                    IsSuccess = false,
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<BidOfferUpdatePageDTO>> UpdateGet(Guid id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "SELECT Id, OfferAmount, BaseUserId, BidId, Explanation FROM BidOffer WHERE Id = @id";
                    var parameters = new { id = id };
                    var initialInfo = connection.QueryFirstOrDefault<BidOfferUpdatePageWithoutListsDTO>(query, parameters);

                    var baseUserQUery = @"SELECT Id, Username as Name from BaseUser ORDER BY Username";
                    var baseUserResult = await connection.QueryAsync<IdNameListDTO>(baseUserQUery);
                    List<IdNameListDTO> baseUserList = baseUserResult.ToList();

                    var bidQuery = @"SELECT Id, BidName as Name FROM Bid ORDER BY BidName";
                    var bidResult = await connection.QueryAsync<IdNameListDTO>(bidQuery);
                    List<IdNameListDTO> bidList = bidResult.ToList();

                    BidOfferUpdatePageDTO responseDTO = new BidOfferUpdatePageDTO(initialInfo.Id, initialInfo.OfferAmount, initialInfo.BaseUserId, initialInfo.BidId, initialInfo.Explanation, baseUserList, bidList);

                    return new ResponseModel<BidOfferUpdatePageDTO>()
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

                return new ResponseModel<BidOfferUpdatePageDTO>()
                {
                    Data = new BidOfferUpdatePageDTO(Guid.Empty, 0, Guid.Empty, Guid.Empty, "", new List<IdNameListDTO>(), new List<IdNameListDTO>()),
                    IsSuccess = false,
                    statusCode = Common.Validation.StatusCode.TimeOut,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> UpdatePost(BidOfferUpdateSendDTO dto)
        {
            try
            {
                var query = "UPDATE BidOffer SET BaseUserId = @baseUserId, BidId = @bidId, OfferAmount = @offerAmount, Explanation = @explanation, ModifiedBy = @modifiedBy, ModifiedDate = GETDATE() where Id = @id";
                var parameters = new { id = dto.Id, baseUserId = dto.BaseUserId, bidId = dto.BidId, offerAmount = dto.OfferAmount, explanation = dto.Explanation, modifiedBy = dto.ModifiedBy };

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
