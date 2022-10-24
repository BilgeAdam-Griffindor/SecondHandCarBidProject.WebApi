using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Logs.Abstract;

namespace SecondHandCarBidProject.WebApi.Controllers.Status
{
    //TODO FILL
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        /// <summary>
        /// For Load and Filter Requests that comes from Status View
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        ILogCatcherMongoLog log;
        public StatusController(ILogCatcherMongoLog _log)
        {
            log = _log;
        }
        [HttpGet("Get-Status")]
        public ResponseModel<StatusTypeDTO> GetStatus(string filter = "")
        {
            if (filter == "")
            {

            }
            else
            {

            }

            return new ResponseModel<StatusTypeDTO>();
        }

        [HttpPut("Update")]
        public ResponseModel<UpdateStatusResponseDTO> UpdateStatus(UpdateStatusTypeDTO dto)
        {


            return new ResponseModel<UpdateStatusResponseDTO>();
        }

        [HttpDelete("Delete")]
        public ResponseModel<DeleteStatusTypeResponseDTO> DeleteStatus(int id)
        {


            return new ResponseModel<DeleteStatusTypeResponseDTO>();
        }

        [HttpPost("Add")]
        public ResponseModel<AddStatusTypeResponseDTO> AddStatus(StatusTypeDTO dto)
        {


            return new ResponseModel<AddStatusTypeResponseDTO>();
        }
    }
}
