using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to profile operations.
    /// For example listing adverts, favorite searches, sold, bought cars.
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
    }
}
