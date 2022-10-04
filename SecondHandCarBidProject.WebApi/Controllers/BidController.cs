using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to bid operations.
    /// For example, adding a new bid or updating, listing existing bids. 
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
    }
}
