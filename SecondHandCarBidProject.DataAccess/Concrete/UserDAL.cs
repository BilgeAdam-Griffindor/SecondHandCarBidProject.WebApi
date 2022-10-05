using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.Validation;
using SecondHandCarBidProject.DataAccess.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class UserDAL : IUserDAL
    {
        private IConfiguration _configuration;

        public UserDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //esranın donus tipi gelecek
        public Task<ExampleDTO> Authenticate(TokenUserRequestDTO req)
        {
            ResponseModel<ExampleDTO> responseModel = new ResponseModel<ExampleDTO>();
            if (string.IsNullOrWhiteSpace(req.LoginUser) ||
             string.IsNullOrWhiteSpace(req.LoginPassword))
            {
                return null;
            }

            //dbden user bilgisi gelecek

            //İşte burada exampleDTO yerine kendi dto doldurulacak.

            /* Db'ye gittik ve girilen inputlara uygun bir kayıt bulamadık mesela :
                responseModel.businessValidationRule = BusinessValidationRule.BadRequest;
                responseModel.IsSuccess = false;
            */

            var secretKey = _configuration.GetSection("JwtTokenKey").Value;
            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var tokenDesc = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
              {
                  // new Claim(ClaimTypes.Name, user.Id.ToString()) 
              }),
                NotBefore = DateTime.Now, // ToUTC 
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var newToken = tokenHandler.CreateToken(tokenDesc);

            return null;
        }
    }
}
