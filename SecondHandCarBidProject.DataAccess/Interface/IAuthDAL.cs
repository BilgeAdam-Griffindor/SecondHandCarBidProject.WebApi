using SecondHandCarBidProject.Common.DTOs;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IAuthDAL
    {
        Task<ResponseModel<TokenDTO>> LoginAsync(string username, string password, int accessTokenLifeTime);
        Task<ResponseModel<TokenDTO>> RefreshTokenLoginAsync(string refreshToken);
    }
}
