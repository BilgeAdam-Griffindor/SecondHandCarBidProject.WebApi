namespace SecondHandCarBidProject.Common.DTOs.CarBuyStatusHistory
{
    public record CarBuyStatusHistoryAddSendDTO(
        Guid CarBuyId,
        int StatusValueId,
        string Explanation,
        Guid CreatedBy
        );
}
