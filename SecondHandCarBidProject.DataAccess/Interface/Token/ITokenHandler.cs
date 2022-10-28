using SecondHandCarBidProject.Common.DTOs;

namespace SecondHandCarBidProject.DataAccess.Interface.Token
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int minute, BaseUserDTO user);
        string CreateRefreshToken();
        Task UpdateRefreshToken(string refreshToken, BaseUserDTO user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
