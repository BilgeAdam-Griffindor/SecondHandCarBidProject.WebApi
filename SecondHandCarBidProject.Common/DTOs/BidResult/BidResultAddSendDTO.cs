namespace SecondHandCarBidProject.Common.DTOs.BidResult
{
    public record BidResultAddSendDTO(
        Guid BidOfferId,
        string Explanation,
        Guid CreatedBy
        );
}
