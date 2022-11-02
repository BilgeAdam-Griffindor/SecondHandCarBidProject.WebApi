namespace SecondHandCarBidProject.Common.DTOs.CarBuyStatusHistory
{
    public record CarBuyStatusHistoryAddPageDTO(
        List<IdNameListDTO> CarBuyList,
        List<IdNameListDTO> StatusValueList
        );
}
