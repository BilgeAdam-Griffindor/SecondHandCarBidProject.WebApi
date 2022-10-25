namespace SecondHandCarBidProject.Common.DTOs.CarBuyAdditionalFee
{
    public record CarBuyAdditionalFeeAddSendDTO(
        Guid CarBuyId,
        Guid NotaryFeeId,
        Guid CommissionFeeId,
        Guid CreatedBy
        );
}
