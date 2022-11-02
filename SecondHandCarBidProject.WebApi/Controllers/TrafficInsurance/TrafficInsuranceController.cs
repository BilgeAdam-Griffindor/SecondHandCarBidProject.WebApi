using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceDTO;
using SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance;

namespace SecondHandCarBidProject.WebApi.Controllers.TrafficInsurance
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficInsuranceController : ControllerBase
    {
        ITrafficInsuranceDAL _trafficInsuranceDAL;
        public TrafficInsuranceController(ITrafficInsuranceDAL trafficInsuranceDAL)
        {
            _trafficInsuranceDAL = trafficInsuranceDAL;
        }
        [HttpGet("List")]
        public async Task<ResponseModel<TrafficInsuranceListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var data = await _trafficInsuranceDAL.List(page, itemPerPage);
            return data;
        }
        [HttpGet("AddGet")]
        public async Task<ResponseModel<TrafficInsuranceAddGetDto>> AddGet()
        {
            var data = await _trafficInsuranceDAL.AddGet();
            return data;
        }
        [HttpPost("Add")]
        public async Task<ResponseModel<bool>> Add(TrafficInsuranceAddDto trafficInsuranceAddDto)
        {
            var data = await _trafficInsuranceDAL.Add(trafficInsuranceAddDto);
            return data;
        }
        [HttpDelete("Delete")]
        public async Task<ResponseModel<bool>> Delete(Guid id)
        {
            var data = await _trafficInsuranceDAL.Delete(id);
            return data;
        }
        [HttpPut("Update")]
        public async Task<ResponseModel<bool>> Update(TrafficInsuranceUpdateDto trafficInsuranceUpdateDto)
        {
            var data = await _trafficInsuranceDAL.Update(trafficInsuranceUpdateDto);
            return data;
        }
        [HttpPut("UpdateGet")]
        public async Task<ResponseModel<TrafficInsuranceUpdateGetDto>> UpdateGet(Guid id)
        {
            var data = await _trafficInsuranceDAL.UpdateGet(id);
            return data;
        }
    }
}
