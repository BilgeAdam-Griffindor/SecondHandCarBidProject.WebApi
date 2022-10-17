using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.DataAccess.Interface;
using SecondHandCarBidProject.DataAccess.Interface.Token;

namespace SecondHandCarBidProject.DataAccess.Concrete
{
    public class AuthDAL : IAuthDAL
    {
        readonly ITokenHandler _tokenHandler;
        public AuthDAL(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }
        public async Task<ResponseModel<TokenDTO>> LoginAsync(string username, string password, int accessTokenLifeTime)
        {
            TokenDTO tokenDTO = null;
            //check user
            //if user exists;
            ExampleDTO user = new ExampleDTO()
            {
                UserID = 1,
                Email = "emre@gmail.com",
                Password = "12345"
            };
            if (user.Email == username && user.Password == password)
            {
                tokenDTO = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);//todo:user parameter
            }
            //TokenDTO tokenDTO = _tokenHandler.CreateAccessToken(accessTokenLifeTime);//todo:user parameter
            //then update refreshtoken
            //  await _tokenHandler.UpdateRefreshToken(tokenDTO.RefreshToken, userid, tokenDTO.Expiration, 5);
            ResponseModel<TokenDTO> responseModel = new ResponseModel<TokenDTO>()
            {
                businessValidationRule = Common.Validation.BusinessValidationRule.Success,
                IsSuccess = true,
                Data = tokenDTO,
                Errors = null
            };
            return responseModel;
        }

        public async Task<ResponseModel<TokenDTO>> RefreshTokenLoginAsync(string refreshToken)
        {
            //if user exists and refresh token duration is valid;
            //if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            //{
            //    TokenDTO tokenDTO = _tokenHandler.CreateAccessToken(30);//todo:user parameter
            //    await _tokenHandler.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 300);
            //    ResponseModel<TokenDTO> response = new ResponseModel<TokenDTO>()
            //    {
            //        Data = tokenDTO,
            //        IsSuccess = true,
            //        businessValidationRule = Common.Validation.BusinessValidationRule.Success,
            //        Errors = null
            //    };
            //    return response;
            //}
            //else
            //    return null;

            return null;
        }
    }
}
