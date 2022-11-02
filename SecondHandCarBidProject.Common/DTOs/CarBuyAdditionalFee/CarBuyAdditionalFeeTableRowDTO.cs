namespace SecondHandCarBidProject.Common.DTOs.CarBuyAdditionalFee
{
    public record CarBuyAdditionalFeeTableRowDTO(
        Guid Id,
        string BrandName,
        string ModelName,
        decimal PreValuationPrice,
        decimal BidPrice,
        string CarOwnerUser,
        decimal NotaryFee,
        decimal CommissionFee,
        DateTime CreatedDate
        );
}
