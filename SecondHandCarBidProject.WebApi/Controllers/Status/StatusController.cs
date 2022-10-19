using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;

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
        [HttpGet("Get-Status")]
        public ResponseModel<StatusDTO> GetStatus(string filter = "")
        {
            if (filter == "")
            {

            }
            else
            {

            }

            return new ResponseModel<StatusDTO>();
        }

        [HttpPut("Update")]
        public ResponseModel<UpdateStatusResponseDTO> UpdateStatus(UpdateStatusDTO dto)
        {


            return new ResponseModel<UpdateStatusResponseDTO>();
        }

        [HttpDelete("Delete")]
        public ResponseModel<DeleteStatusResponseDTO> DeleteStatus(int id)
        {


            return new ResponseModel<DeleteStatusResponseDTO>();
        }

        [HttpPost("Add")]
        public ResponseModel<AddStatusResponseDTO> AddStatus(StatusDTO dto)
        {


            return new ResponseModel<AddStatusResponseDTO>();
        }
    }
}
