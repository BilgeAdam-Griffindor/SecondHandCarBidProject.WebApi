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
    }
}
