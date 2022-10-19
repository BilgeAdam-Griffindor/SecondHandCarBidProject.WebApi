using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.DataAccess.Interface;

namespace SecondHandCarBidProject.WebApi.Controllers.Bid
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidCorporationController : ControllerBase
    {
        public IBidCorporationDAL _bidCorpDAL;

        public BidCorporationController(IBidCorporationDAL bidCorpDAL)
        {
            _bidCorpDAL = bidCorpDAL;
        }

        [HttpGet("List")]
        public async Task<ResponseModel<BidCorporationListPageDTO>> List(int page = 1, int itemPerPage = 100)
        {
            return await _bidCorpDAL.List(page, itemPerPage);
        }

        [HttpGet("AddGet")]
        public async Task<ResponseModel<BidCorporationAddPageDTO>> AddGet()
        {
            return await _bidCorpDAL.AddGet();
        }

        [HttpPost("AddPost")]
        public async Task<ResponseModel<bool>> AddPost(BidCorporationAddSendDTO dto)
        {
            return await _bidCorpDAL.AddPost(dto);
        }

        [HttpDelete("Delete")]
        public async Task<ResponseModel<bool>> Delete(Guid bidId, int corporationId, Guid modifiedBy)
        {
            return await _bidCorpDAL.Delete(bidId, corporationId, modifiedBy);
        }
    }
}
