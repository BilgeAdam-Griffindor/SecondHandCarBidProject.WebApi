using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to car operations. For admin use only.
    /// For example, adding a new car or updating, listing existing cars.
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class AdminCarController : ControllerBase
    {
        [Authorize]
        [HttpGet("GetDataForCarListPage")]
        public void GetDataForCarListPage(int? brandId = null, int? modelId = null, int? statusId = null, int page = 1, int itemPerPage = 100)
        {

        }
    }
}
