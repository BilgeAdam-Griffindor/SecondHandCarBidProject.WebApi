namespace SecondHandCarBidProject.Common.DTOs.BidOffer
{
    public record BidOfferUpdateSendDTO(
        Guid Id,
        decimal OfferAmount,
        Guid BaseUserId,
        Guid BidId,
        string Explanation,
        Guid ModifiedBy
        );
}
