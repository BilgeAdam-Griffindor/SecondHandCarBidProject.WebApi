namespace SecondHandCarBidProject.Common.DTOs
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        //public StatusCode statusCode
        //{
        //    get
        //    {
        //        if (IsSuccess)
        //        {
        //            return StatusCode.Success;
        //        }
        //        else
        //        {
        //            return statusCode;
        //        }
        //    }
        //    set
        //    {
        //        if (!IsSuccess)
        //        {
        //            statusCode = value;
        //        }
        //    }
        //}
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

}
