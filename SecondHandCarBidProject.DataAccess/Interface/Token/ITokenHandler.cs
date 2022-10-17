using SecondHandCarBidProject.Common.DTOs;

namespace SecondHandCarBidProject.DataAccess.Interface.Token
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int minute, ExampleDTO user);//todo: user parametre
        string CreateRefreshToken();
        Task UpdateRefreshToken(string refreshToken, ExampleDTO user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
