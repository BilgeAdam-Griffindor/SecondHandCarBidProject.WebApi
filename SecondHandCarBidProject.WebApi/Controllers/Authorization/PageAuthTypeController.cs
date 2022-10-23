using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.DataAccess.Context;

namespace SecondHandCarBidProject.WebApi.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageAuthTypeController : ControllerBase
    {
        private readonly DapperContext _context;
        public PageAuthTypeController()
        {

        }
        
    }
}
