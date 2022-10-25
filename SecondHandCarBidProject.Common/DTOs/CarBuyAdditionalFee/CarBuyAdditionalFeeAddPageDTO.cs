namespace SecondHandCarBidProject.Common.DTOs.CarBuyAdditionalFee
{
    public record CarBuyAdditionalFeeAddPageDTO(
        List<IdNameListDTO> CarBuyList,
        List<IdNameListDTO> NotaryFeeList,
        List<IdNameListDTO> CommissionFeeList
        );
}
