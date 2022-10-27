using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.DataAccess.Interface;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAdressInfoDAL _addressDAL;
        public AddressController(IAdressInfoDAL adressInfoDAL)
        {
            _addressDAL = adressInfoDAL;
        }
        [HttpGet("GetAddresses")]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _addressDAL.GetAllAdresses();


            return Ok(addresses);
        }
    }
}
