namespace SecondHandCarBidProject.Common.DTOs.BidStatusHistory
{
    public record BidStatusHistoryListTableRowsDTO(
        Guid Id,
        string BidName,
        string StatusName,
        string Explanation,
        DateTime CreatedDate
        );
}
