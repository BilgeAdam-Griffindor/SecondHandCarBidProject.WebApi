namespace SecondHandCarBidProject.Common.DTOs.CarBuy
{
    public record CarBuyUpdateSendDTO(
        Guid Id,
        int StatusId,
        decimal? PreValuationPrice,
        decimal? BidPrice,
        Guid ModifiedBy
        );
}
