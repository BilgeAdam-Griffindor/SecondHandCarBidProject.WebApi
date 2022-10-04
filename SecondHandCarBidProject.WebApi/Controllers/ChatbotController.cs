using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    /// <summary>
    /// Related to chatbot operations.
    /// </summary>
    [Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ChatbotController : ControllerBase
    {
    }
}
