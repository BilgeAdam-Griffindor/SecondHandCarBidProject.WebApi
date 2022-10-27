using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.StatusTypeDTO;
using SecondHandCarBidProject.DataAccess.Interface.IStatus;
using SecondHandCarBidProject.Logs.Abstract;

namespace SecondHandCarBidProject.WebApi.Controllers.Status
{
    //TODO FILL
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTypeController : ControllerBase
    {
        IStatusTypeDAL _statusTypeDAL;
        /// <summary>
        /// For Load and Filter Requests that comes from Status View
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        ILogCatcherMongoLog log;
        public StatusTypeController(ILogCatcherMongoLog _log, IStatusTypeDAL statusTypeDAL)
        {
            log = _log;
            _statusTypeDAL = statusTypeDAL;
        }
        [HttpGet("List")]
        public async Task<ResponseModel<StatusTypeListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var data = await _statusTypeDAL.List(page, itemPerPage);
            return data;

        }

        [HttpPut("Update")]
        public async Task<ResponseModel<bool>> Update(StatusTypeUpdateDto statusTypeUpdateDto)
        {
            var data = await _statusTypeDAL.Update(statusTypeUpdateDto);
            return data;
        }

        [HttpDelete("Delete")]
        public async Task<ResponseModel<bool>> Delete(short id)
        {
            var data = await _statusTypeDAL.Delete(id);
            return data;
        
        }

        [HttpPost("Add")]
        public async Task<ResponseModel<bool>> Add(StatusTypeAddDTO statusTypeAddDto)
        {
            var data = await _statusTypeDAL.Add(statusTypeAddDto);
            return data;

         
        }
    }
}
