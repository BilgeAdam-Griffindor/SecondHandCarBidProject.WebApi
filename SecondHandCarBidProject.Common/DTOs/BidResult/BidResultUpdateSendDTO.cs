namespace SecondHandCarBidProject.Common.DTOs.BidResult
{
    public record BidResultUpdateSendDTO(
        Guid Id,
        string Explanation,
        Guid ModifiedBy
        );
}
