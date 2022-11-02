namespace SecondHandCarBidProject.Common.DTOs.BidOffer
{
    public record BidOfferAddSendDTO(
        decimal OfferAmount,
        Guid BaseUserId,
        Guid BidId,
        string Explanation,
        Guid CreatedBy
        );
}
