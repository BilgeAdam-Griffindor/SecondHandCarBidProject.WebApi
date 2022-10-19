namespace SecondHandCarBidProject.Common.DTOs
{
    public record BidCorporationListTableRowsDTO(
        Guid BidId,
        int CorporationId,
        string BidName,
        string CompanyName
        );
}
