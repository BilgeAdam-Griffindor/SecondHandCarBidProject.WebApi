using Dapper;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.BidOffer;
using SecondHandCarBidProject.Common.DTOs.BidStatusHistory;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    internal class BidStatusHistoryDAL : IBidStatusHistoryDAL
    {
        private readonly DapperContext _context;

        public BidStatusHistoryDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<BidStatusHistoryAddPageDTO>> AddGet()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var bidQuery = @"SELECT Id, BidName as Name FROM Bid ORDER BY BidName";
                    var bidResult = await connection.QueryAsync<IdNameListDTO>(bidQuery);
                    List<IdNameListDTO> bidList = bidResult.ToList();

                    var statusValueQuery = "SELECT Id, StatusName as Name FROM StatusValue WHERE StatusTypeId = 2";
                    var statusValueResult = await connection.QueryAsync<IdNameListDTO>(statusValueQuery);
                    List<IdNameListDTO> statusValueList = statusValueResult.ToList();

                    BidStatusHistoryAddPageDTO responseDTO = new BidStatusHistoryAddPageDTO(bidList, statusValueList);

                    return new ResponseModel<BidStatusHistoryAddPageDTO>()
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

                return new ResponseModel<BidStatusHistoryAddPageDTO>()
                {
                    Data = new BidStatusHistoryAddPageDTO(new List<IdNameListDTO>(), new List<IdNameListDTO>()),
                    IsSuccess = false,

                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> AddPost(BidStatusHistoryAddSendDTO dto)
        {
            try
            {
                var query = "INSERT INTO BidStatusHistory (Id, BidId, StatusValueId, Explanation, CreatedBy) values(NEWID(), @bidId, @statusId, @explanation, @createdBy)";
                var parameters = new { bidId = dto.BidId, statusId = dto.StatusValueId, explanation = dto.Explanation, createdBy = dto.CreatedBy };
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

        public async Task<ResponseModel<bool>> Delete(Guid id)
        {
            try
            {
                var query = @"DELETE FROM BidStatusHistory WHERE Id=@id";
                var parameters = new { id = id };
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

        public async Task<ResponseModel<BidStatusHistoryListPageDTO>> List(int page = 1, int itemPerPage = 100)
        {
            try
            {
                var query = @"SELECT bsh.Id, b.BidName, sv.StatusName, bsh.CreatedDate
	                        FROM BidStatusHistory bsh
	                        JOIN Bid b on bsh.BidId = b.Id
	                        JOIN StatusValue sv on bsh.StatusValueId = sv.Id
	                        WHERE bsh.IsActive = 1
	                        ORDER BY bsh.Id DESC
	                        OFFSET (@page - 1) * @itemPerPage ROWS FETCH NEXT @itemPerPage ROWS ONLY";
                var parameters = new { page = page, itemPerPage = itemPerPage };
                using (var connection = _context.CreateConnection())
                {
                    var bidStatusHistoryResult = await connection.QueryAsync<BidStatusHistoryListTableRowsDTO>(query, parameters);
                    List<BidStatusHistoryListTableRowsDTO> bidStatusHistoryList = bidStatusHistoryResult.ToList();

                    int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM BidOffer"));
                    maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);

                    BidStatusHistoryListPageDTO responseDTO = new BidStatusHistoryListPageDTO(bidStatusHistoryList, maxPage);

                    return new ResponseModel<BidStatusHistoryListPageDTO>()
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

                return new ResponseModel<BidStatusHistoryListPageDTO>()
                {
                    Data = new BidStatusHistoryListPageDTO(new List<BidStatusHistoryListTableRowsDTO>(), 0),
                    IsSuccess = false,

                    Errors = errors
                };
            }
        }
    }
}
