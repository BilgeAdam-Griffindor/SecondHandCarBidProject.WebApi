using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to car operations.
    /// For example, adding a new car or updating, listing existing cars. 
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
    }
}
