using SecondHandCarBidProject.Common.Validation;

namespace SecondHandCarBidProject.Common.DTOs
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public BusinessValidationRule businessValidationRule { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }

}
