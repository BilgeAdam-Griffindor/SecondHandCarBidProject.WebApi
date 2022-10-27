namespace SecondHandCarBidProject.Common.DTOs.CarBuyStatusHistory
{
    public record CarBuyStatusHistoryTableRow(
        Guid Id,
        string BrandName,
        string ModelName,
        decimal PreValuationPrice,
        decimal BidPrice,
        string CarOwner,
        string Status,
        string Explanation,
        DateTime CreatedDate
        );
}
