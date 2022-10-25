namespace SecondHandCarBidProject.Common.DTOs.BidResult
{
    public record BidResultListTableRowsDTO(
        Guid Id,
        string BidName,
        decimal OfferAmount,
        string OfferExplanation,
        string OfferOwnerName,
        string ResultExplanation
        );
}
