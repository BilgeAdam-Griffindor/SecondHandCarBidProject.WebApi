using SecondHandCarBidProject.Common.DTOs;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IUserDAL
    {
        //esranın vereceği tipi dönecek...
        Task<string> Authenticate(TokenUserRequestDTO req);
    }
}
