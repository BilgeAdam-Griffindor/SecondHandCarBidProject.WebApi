using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.StatusValueDTO;
using SecondHandCarBidProject.Common.DTOs.StatusValueDTO.Temp;
using SecondHandCarBidProject.DataAccess.Interface.IStatus;

namespace SecondHandCarBidProject.WebApi.Controllers.Status
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusValueController : ControllerBase
    {
        IStatusValueDAL _statusValueDAL;
        public StatusValueController(IStatusValueDAL statusValueDAL)
        {
            _statusValueDAL = statusValueDAL;
        }
        [HttpGet("List")]
        public async Task<ResponseModel<StatusValueListDto>> List()
        {
            var data = await _statusValueDAL.List();
            return data;
        }
        [HttpGet("AddGet")]
        public async Task<ResponseModel<StatusValueAddGetDto>> AddGet()
        {
            var data = await _statusValueDAL.AddGet();
            return data;
        }
        [HttpPost("UpdateGet")]
        public async Task<ResponseModel<StatusValueUpdateGetDto>> UpdateGet(int id)
        {
            var data = await _statusValueDAL.UpdateGet(id);
            return data;
        }
        [HttpPut("Update")]
        public async Task<ResponseModel<bool>> Update(StatusValueUpdateDto statusValueUpdateDto)
        {
            var data = await _statusValueDAL.Update(statusValueUpdateDto);
            return data;
        }
        [HttpDelete("Delete")]
        public async Task<ResponseModel<bool>> Delete(int id)
        {
            var data = await _statusValueDAL.Delete(id);
            return data;
        }
    }
}
