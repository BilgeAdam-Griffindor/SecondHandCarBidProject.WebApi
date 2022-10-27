using SecondHandCarBidProject.Common.DTOs;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IAuthDAL
    {
        Task<ResponseModel<UserResponseDTO>> LoginAsync(string Username, string password, int accessTokenLifeTime);
        Task<ResponseModel<bool>> RegisterAsync(BaseUserAddDTO user);
        Task<ResponseModel<TokenDTO>> RefreshTokenLoginAsync(string refreshToken);
    }
}
