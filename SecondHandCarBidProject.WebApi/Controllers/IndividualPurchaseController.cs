using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to individual purchase operations. CarBuy table?
    /// For example listing the cars available to individual purchase.
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class IndividualPurchaseController : ControllerBase
    {
    }
}
