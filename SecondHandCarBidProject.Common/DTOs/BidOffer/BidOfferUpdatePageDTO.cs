namespace SecondHandCarBidProject.Common.DTOs.BidOffer
{
    public record BidOfferUpdatePageDTO(
        Guid Id,
        decimal OfferAmount,
        Guid BaseUserId,
        Guid BidId,
        string Explanation,
        List<IdNameListDTO> BaseUserList,
        List<IdNameListDTO> BidList
        );
}
