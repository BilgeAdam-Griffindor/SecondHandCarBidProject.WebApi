namespace SecondHandCarBidProject.Common.DTOs.BidCorporation
{
    public record BidCorporationAddSendDTO(
        Guid BidId,
        int CorporationId,
        Guid CreatedBy
        );
}
