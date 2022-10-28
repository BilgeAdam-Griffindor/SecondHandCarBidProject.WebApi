using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs.BidCorporation;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.DataAccess.Interface;
using SecondHandCarBidProject.Common.DTOs.Bid;

namespace SecondHandCarBidProject.WebApi.Controllers.Bid
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        IBidDAL _bidDAL;
        public BidController(IBidDAL bidDAL)
        {
            _bidDAL = bidDAL;
        }

        [HttpGet("AddGetUser")]
        public async Task<ResponseModel<BidAddPageUserDTO>> AddGetUser(Guid userId, bool isCorporate)
        {
            return await _bidDAL.AddGetUser(userId, isCorporate);
        }

        [HttpPost("AddPostUser")]
        public async Task<ResponseModel<bool>> AddPostUser(BidAddSendUserDTO dto)
        {
            return await _bidDAL.AddPostUser(dto);
        }
    }
}
