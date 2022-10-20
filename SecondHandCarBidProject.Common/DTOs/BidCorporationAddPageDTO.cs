namespace SecondHandCarBidProject.Common.DTOs
{
    public record BidCorporationAddPageDTO(
        List<IdNameListDTO> BidList,
        List<IdNameListDTO> CorporationList
        );
}
