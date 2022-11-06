using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceTrafficInsuranceCarComponentDTO;
using SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance;

namespace SecondHandCarBidProject.WebApi.Controllers.TrafficInsurance
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficInsuranceTrafficInsuranceCarComponentController : ControllerBase
    {
        ITrafficInsuranceTrafficInsuranceCarComponentDAL _Ititiccd;
        public TrafficInsuranceTrafficInsuranceCarComponentController(ITrafficInsuranceTrafficInsuranceCarComponentDAL Ititiccd)
        {
            _Ititiccd = Ititiccd;
        }
        [HttpGet("List")]
        public async Task<ResponseModel<TrafficInsuranceTrafficInsuranceCarComponentListDto>> List(int page = 1, int itemPerPage = 10)
        {
            var data = await _Ititiccd.List(page,itemPerPage);
            return data;
        }
        [HttpPost("Add")]
        public async Task<ResponseModel<bool>> Add(TrafficInsuranceTrafficInsuranceCarComponentAddDto titiccad)
        {
            var data = await _Ititiccd.Add(titiccad);
            return data;
        }
    }
}
