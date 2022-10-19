namespace SecondHandCarBidProject.Common.DTOs
{
    public record BidCorporationAddSendDTO(
        Guid BidId,
        int CorporationId,
        Guid CreatedBy
        );
}
