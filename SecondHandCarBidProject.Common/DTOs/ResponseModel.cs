using SecondHandCarBidProject.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public StatusCode statusCode
        {
            get
            {
                if (IsSuccess)
                {
                    return StatusCode.Success;
                }
                else
                {
                    return statusCode;
                }
            }
            set
            {
                if (!IsSuccess)
                {
                    statusCode = value;
                }
            }
        }
        public bool IsSuccess { get; set; }
    }

}
