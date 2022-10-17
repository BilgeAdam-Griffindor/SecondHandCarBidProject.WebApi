using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.DataAccess.Interface.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SecondHandCarBidProject.DataAccess.Concrete.Token
{
    public class TokenHandler : ITokenHandler
    {
        private IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDTO CreateAccessToken(int minute, ExampleDTO user)
        {
            TokenDTO tokenDTO = new TokenDTO();

            //get the security key from appsettings.json
            var secretKey = _configuration.GetSection("JwtToken:SecurityKey").Value;

            //get the symmetry of the security key
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //we generate the encrypted id
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //give the token settings to be created
            tokenDTO.Expiration = DateTime.UtcNow.AddSeconds(minute);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                audience: _configuration["JwtToken:Audience"],
                issuer: _configuration["JwtToken:Issuer"],
                expires: tokenDTO.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                 claims: new List<Claim> { new(ClaimTypes.Name, user.Email) }
                );

            //created the token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenDTO.AccessToken = tokenHandler.WriteToken(securityToken);

            //created refresh token
            string refreshToken = CreateRefreshToken();
            tokenDTO.RefreshToken = refreshToken;

            return tokenDTO;
        }

        //create resfresh token
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);

            return Convert.ToBase64String(number);
        }

        //update resfresh token
        public async Task UpdateRefreshToken(string refreshToken, ExampleDTO user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            //refresh token tablosunda string refreshtoken,datetime expiration,userid tutulacak
            //dbdeb userid ye göre user gelicek.user varsa refreshtokendbye user ve refreshtoken eklenecek
            //if (user != null)
            //{
            //    //todo:refresh token will add to refreshtoken table 
            //    user.RefreshToken = refreshToken;
            //    user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDate);
            //    //await _userdal.UpdateAsync(user);
            //}

        }
    }
}
