using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to stock operations. For admin use only.
    /// For example listing the current stock of corporations.
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class AdminStockController : ControllerBase
    {
    }
}
