using Dapper;
using MongoDB.Driver;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.BidCorporation;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class BidCorporationDAL : IBidCorporationDAL
    {
        private readonly DapperContext _context;

        public BidCorporationDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<BidCorporationAddPageDTO>> AddGet()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var bidQuery = "SELECT Id, BidName as Name FROM Bid";
                    var bid = await connection.QueryAsync<IdNameListDTO>(bidQuery);
                    List<IdNameListDTO> bidCorporationsList = bid.ToList();

                    var corporationQuery = "SELECT Id as Id, CompanyName as Name FROM Corporation";
                    var corporations = await connection.QueryAsync<IdNameListDTO>(corporationQuery);
                    List<IdNameListDTO> corporationsList = corporations.ToList();

                    BidCorporationAddPageDTO responseDTO = new BidCorporationAddPageDTO(bidCorporationsList, corporationsList);

                    return new ResponseModel<BidCorporationAddPageDTO>()
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

                return new ResponseModel<BidCorporationAddPageDTO>()
                {
                    Data = new BidCorporationAddPageDTO(new List<IdNameListDTO>(), new List<IdNameListDTO>()),
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }

        public async Task<ResponseModel<bool>> AddPost(BidCorporationAddSendDTO dto)
        {
            try
            {
                var query = "EXEC BidCorporationAdd @bidId, @corporationId, @createdBy";
                var parameters = new { bidId = dto.BidId, corporationId = dto.CorporationId, createdBy = dto.CreatedBy };
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

        public async Task<ResponseModel<bool>> Delete(Guid bidId, int corporationId, Guid modifiedBy)
        {
            try
            {
                var query = "EXEC BidCorporationDelete @bidId, @corporationId, @modifiedBy";
                var parameters = new { bidId = bidId, corporationId = corporationId, modifiedBy = modifiedBy };
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(query, parameters);

                    return new ResponseModel<bool>()
                    {
                        Data = result > 0,
                        IsSuccess = true
                        //  
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

        public async Task<ResponseModel<BidCorporationListPageDTO>> List(int page = 1, int itemPerPage = 100)
        {
            try
            {
                var query = "EXEC BidCorporationList @page, @itemPerPage";
                var parameters = new { page = page, itemPerPage = itemPerPage };
                using (var connection = _context.CreateConnection())
                {
                    var bidCorporations = await connection.QueryAsync<BidCorporationListTableRowsDTO>(query, parameters);
                    List<BidCorporationListTableRowsDTO> bidCorporationsList = bidCorporations.ToList();

                    int maxPage = Convert.ToInt32(await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM BidCorporation"));
                    maxPage = (int)Math.Ceiling((double)maxPage / itemPerPage);

                    BidCorporationListPageDTO responseDTO = new BidCorporationListPageDTO(bidCorporationsList, maxPage);

                    return new ResponseModel<BidCorporationListPageDTO>()
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

                return new ResponseModel<BidCorporationListPageDTO>()
                {
                    Data = new BidCorporationListPageDTO(new List<BidCorporationListTableRowsDTO>(), 0),
                    IsSuccess = false,
                    Errors = errors
                };
            }
        }
    }
}
