namespace SecondHandCarBidProject.Common.DTOs.BidStatusHistory
{
    public record BidStatusHistoryAddSendDTO(
        Guid BidId,
        Guid StatusValueId,
        string Explanation,
        Guid CreatedBy
        );
}
