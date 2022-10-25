namespace SecondHandCarBidProject.Common.DTOs.CarBuy
{
    public record CarDetailAddPageDTO(
        List<IdNameListDTO> BrandList,
        List<IdNameListDTO> ModelList,
        List<IdNameListDTO> StatusList,
        List<IdNameListDTO> CorporationList,
        List<IdNameListDTO> BodyTypeList,
        List<IdNameListDTO> FuelTypeList,
        List<IdNameListDTO> GearTypeList,
        List<IdNameListDTO> VersionList,
        List<IdNameListDTO> ColorList,
        List<IdNameListDTO> OptionalHardwareList
        );
}
