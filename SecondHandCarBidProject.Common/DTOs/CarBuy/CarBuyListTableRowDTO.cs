namespace SecondHandCarBidProject.Common.DTOs.CarBuy
{
    public record CarBuyListTableRowDTO(
       Guid Id,
       string BrandName,
       string ModelName,
       decimal PreValuationPrice,
       decimal BidPrice,
       string Status,
       string CarOwner,
       DateTime CreatedDate
       );
}
