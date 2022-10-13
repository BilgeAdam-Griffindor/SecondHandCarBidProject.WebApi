using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.DataAccess.Interface;

namespace SecondHandCarBidProject.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserDAL _userDAL;

        public LoginController(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Authenticate([FromBody] TokenUserRequestDTO req)
        {
            if (req == null)
                return BadRequest(new { message = "Kullanıcı adı veya şifre hatalı!" });

            var result = await _userDAL.Authenticate(req);
            if (result == null)
                return Unauthorized();//if it is null it will return 401(Unauthorized) code
            
            return Ok(result);
        }
    }
}
