using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceCarComponentDTO;
using SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance;

namespace SecondHandCarBidProject.WebApi.Controllers.TrafficInsurance
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficInsuranceCarComponentController : ControllerBase
    {
        ITrafficInsuranceCarComponentDAL _trafficInsuranceCarComponentDAL;
        public TrafficInsuranceCarComponentController(ITrafficInsuranceCarComponentDAL trafficInsuranceCarComponentDAL)
        {
            _trafficInsuranceCarComponentDAL = trafficInsuranceCarComponentDAL;
        }
        [HttpGet("List")]
        public async Task<ResponseModel<TrafficInsuranceCarComponentListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var data = await _trafficInsuranceCarComponentDAL.List(page, itemPerPage);
            return data;
        }
        [HttpPost("Add")]
        public async Task<ResponseModel<bool>> Add(TrafficInsuranceCarComponentAddDto trafficInsuranceCarComponentAddDto)
        {
            var data = await _trafficInsuranceCarComponentDAL.Add(trafficInsuranceCarComponentAddDto);
            return data;
        }
        [HttpPut("Update")]
        public async Task<ResponseModel<bool>> Update(TrafficInsuranceCarComponentUpdateDto trafficInsuranceCarComponentUpdateDto)
        {
            var data = await _trafficInsuranceCarComponentDAL.Update(trafficInsuranceCarComponentUpdateDto);
            return data;
        }
        [HttpPut("Delete")]
        public async Task<ResponseModel<bool>> Delete(short id)
        {
            var data = await _trafficInsuranceCarComponentDAL.Delete(id);
            return data;
        }
    }
}
