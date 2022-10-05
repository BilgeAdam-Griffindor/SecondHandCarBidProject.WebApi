using SecondHandCarBidProject.Common.DTOs;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IUserDAL
    {
        //esranın vereceği tipi dönecek...
        Task<ExampleDTO> Authenticate(TokenUserRequestDTO req);
    }
}
