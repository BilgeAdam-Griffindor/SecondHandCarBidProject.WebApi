using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.PageAuthTypeDTO;
using SecondHandCarBidProject.Common.DTOs.RolePageActionAuthDto;
using SecondHandCarBidProject.DataAccess.Interface.IAuthorization;

namespace SecondHandCarBidProject.WebApi.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePageActionAuthController : ControllerBase
    {
        IRolePageActionAuthDAL _rolePageActionAuthDAL;
        public RolePageActionAuthController(IRolePageActionAuthDAL rolePageActionAuthDAL)
        {
            _rolePageActionAuthDAL = rolePageActionAuthDAL;
        }
        [HttpGet("List")]
        public async Task<ResponseModel<RolePageActionAuthListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var data = await _rolePageActionAuthDAL.List(page, itemPerPage);
            return data;
        }
        [HttpGet("AddGet")]
        public async Task<ResponseModel<RolePageActionAuthAddGetDTO>> AddGet()
        {
            var data = await _rolePageActionAuthDAL.AddGet();
            return data;
        }
        [HttpPost("AddPost")]
        public async Task<ResponseModel<bool>> AddPost(RolePageActionAuthAddDto rpa)
        {
            var data = await _rolePageActionAuthDAL.AddPost(rpa);
            return data;
        }
    }
}
