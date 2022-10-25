namespace SecondHandCarBidProject.Common.DTOs.CarBrand
{
    public record CarBrandUpdateSendDTO(
        short Id,
        string BrandName,
        Guid ModifiedBy
        );
}
