using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to getting reports about various things. For admin use only.
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class AdminReportController : ControllerBase
    {
        
    }
}
