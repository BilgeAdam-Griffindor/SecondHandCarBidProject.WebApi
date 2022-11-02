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

        private IAuthDAL _authDAL;

        public LoginController(IAuthDAL authDAL)
        {
            _authDAL = authDAL;
        }
        [AllowAnonymous]

        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login(TokenUserRequestDTO req)

        {
            if (req == null)
                return BadRequest(new { message = "Kullanıcı adı veya şifre hatalı!" });

            var result = await _authDAL.LoginAsync(req.LoginUser, req.LoginPassword, 20);
            //if (result.IsSuccess == false)
            //    return NoContent();

            return Ok(result);
        }
        [AllowAnonymous]

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register(BaseUserAddDTO user)

        {
            if (user == null)
                return BadRequest();

            var result = await _authDAL.RegisterAsync(user);
            //if (result.IsSuccess == false)
            //    return NoContent();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] string refreshToken)
        {

            var result = await _authDAL.RefreshTokenLoginAsync(refreshToken);
            if (result == null)
                return Unauthorized();//if it is null it will return 401(Unauthorized) code

            return Ok(result);
        }
        [Authorize]
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            ExampleDTO exampleDTO = new ExampleDTO()
            {
                UserID = 41,
                Email = "dfhdjhdfj",
                Password = "3454"
            };


            return Ok(exampleDTO);
        }
    }
}
