namespace SecondHandCarBidProject.Common.DTOs.BidOffer
{
    public record BidOfferAddPageDTO(
        List<IdNameListDTO> BaseUserList,
        List<IdNameListDTO> BidList
        );
}
