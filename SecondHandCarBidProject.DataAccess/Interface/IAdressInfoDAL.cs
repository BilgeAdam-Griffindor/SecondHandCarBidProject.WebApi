using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.AddressInfo;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IAdressInfoDAL
    {
        Task<ResponseModel<List<AddressInfoListDTO>>> GetAllAdresses();
    }
}
