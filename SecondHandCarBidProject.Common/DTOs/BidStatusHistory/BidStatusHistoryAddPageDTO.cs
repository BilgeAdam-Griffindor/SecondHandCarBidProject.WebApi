namespace SecondHandCarBidProject.Common.DTOs.BidStatusHistory
{
    public record BidStatusHistoryAddPageDTO(
        List<IdNameListDTO> BidList,
        List<IdNameListDTO> StatusValueList
        );
}
