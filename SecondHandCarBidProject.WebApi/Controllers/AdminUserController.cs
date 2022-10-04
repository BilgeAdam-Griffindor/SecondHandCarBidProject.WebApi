using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to user operatons. For admin use only.
    /// For example, adding, deleting, updating user info, assigning roles.
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
    }
}
