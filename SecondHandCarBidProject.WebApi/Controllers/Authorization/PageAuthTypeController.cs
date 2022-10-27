using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.PageAuthTypeDTO;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface.IAuthorization;

namespace SecondHandCarBidProject.WebApi.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageAuthTypeController : ControllerBase
    {
        private readonly IPageAuthTypeDal _pageAuthTypeDal;
        public PageAuthTypeController(IPageAuthTypeDal pageAuthTypeDal)
        {
            _pageAuthTypeDal= pageAuthTypeDal;
        }
        [HttpGet("List")]
        public async Task<ResponseModel<PageAuthTypeListDTO>> List(int page = 1, int itemPerPage = 10)
        {
            var data = await _pageAuthTypeDal.List(page, itemPerPage);
            return data;
        }
    }
}
