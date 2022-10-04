using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to corporate user operations. For corporate users only.
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class CorporateUserController : ControllerBase
    {
    }
}
