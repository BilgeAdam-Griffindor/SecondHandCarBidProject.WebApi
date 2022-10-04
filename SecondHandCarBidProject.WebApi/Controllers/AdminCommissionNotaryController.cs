using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to commission and notary operations. For admin use only.
    /// For example, adding a new commission, notary fee or update, list existing ones.
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class AdminCommissionNotaryController : ControllerBase
    {
    }
}
