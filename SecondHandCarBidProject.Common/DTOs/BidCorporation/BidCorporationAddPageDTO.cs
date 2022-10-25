namespace SecondHandCarBidProject.Common.DTOs.BidCorporation
{
    public record BidCorporationAddPageDTO(
        List<IdNameListDTO> BidList,
        List<IdNameListDTO> CorporationList
        );
}
