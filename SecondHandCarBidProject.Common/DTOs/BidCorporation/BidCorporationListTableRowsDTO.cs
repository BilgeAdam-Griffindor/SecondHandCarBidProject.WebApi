namespace SecondHandCarBidProject.Common.DTOs.BidCorporation
{
    public record BidCorporationListTableRowsDTO(
        Guid BidId,
        int CorporationId,
        string BidName,
        string CompanyName
        );
}
