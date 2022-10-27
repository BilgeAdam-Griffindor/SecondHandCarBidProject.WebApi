using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.RoleTypeDTO;
using SecondHandCarBidProject.DataAccess.Interface.IAuthorization;

namespace SecondHandCarBidProject.WebApi.Controllers.Role
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleTypeController : ControllerBase
    {
        IRoleTypeDAL _roleTypeDAL;
        public RoleTypeController(IRoleTypeDAL roleTypeDAL)
        {
            _roleTypeDAL = roleTypeDAL;
        }

        [HttpGet("List")]
        public async Task<ResponseModel<RoleTypeListDto>> List()
        {
            var data = await _roleTypeDAL.List();
            return data;
        }
        [HttpPost("Add")]
        public async Task<ResponseModel<bool>> Add(RoleTypeAddDto roleTypeAddDto)
        {
            var data = await _roleTypeDAL.Add(roleTypeAddDto);
            return data;
        }
        [HttpPut("Update")]
        public async Task<ResponseModel<bool>> Update(RoleTypeUpdateDto roleTypeUpdateDto)
        {
            var data = await _roleTypeDAL.Update(roleTypeUpdateDto);
            return data;
        }
        [HttpDelete("Delete")]
        public async Task<ResponseModel<bool>> Delete(short id)
        {
            var data = await _roleTypeDAL.Delete(id);
            return data;
        }

    }
}
