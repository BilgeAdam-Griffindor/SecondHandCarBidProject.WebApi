namespace SecondHandCarBidProject.Common.DTOs.BidOffer
{
    public record BidOfferListTableRowsDTO(
        Guid Id,
        decimal OfferAmount,
        string BaseUserName,
        string BidName,
        string Explanation
        );
}
