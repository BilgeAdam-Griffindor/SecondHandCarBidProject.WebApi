using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Logs.Abstract;

namespace SecondHandCarBidProject.WebApi.Controllers.Status
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        ILogCatcherMongoLog log;
        public StatusController(ILogCatcherMongoLog _log)
        {
            log = _log;
        }
        [HttpGet("Get-Status")]
        public async Task<IActionResult> GetStatus()
        {

            try
            {
                Exception exception = new Exception();
                await log.WriteLogWarning(exception);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok("İşlem Başarılı");
        }
    }
}
