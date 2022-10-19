using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers.Status
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet("Get-Status")]
        public async Task<IActionResult> GetStatus()
        {
            return Ok("İşlem Başarılı");
        }
    }
}
