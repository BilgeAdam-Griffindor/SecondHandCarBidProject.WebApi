namespace SecondHandCarBidProject.Common.DTOs.AddressInfo
{
    public record AddressInfoListDTO(
        int Id,
        string AddressName,
        int TopAddressInfoId,
        int AddressTypeId,
        bool isActive
        );
}
