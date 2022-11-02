namespace SecondHandCarBidProject.Common.DTOs.CarBuy
{
    public record CarBuyAddSendDTO(
        int Kilometre,
        short CarYear,
        string CarDescription,
        short CarBrandId,
        int CarModelId,
        Guid BodyTypeId,
        Guid FuelTypeId,
        Guid GearTypeId,
        Guid VersionId,
        Guid ColorId,
        List<Guid> OptionalHardwareIds,
        List<byte[]> CarImages,
        Guid CreatedBy
        );
}
