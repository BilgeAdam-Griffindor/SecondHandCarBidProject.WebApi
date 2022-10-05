using SecondHandCarBidProject.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs
{
    public class ResponseModel<T> where T : class
    {
        public T Data { get; set; }
        public BusinessValidationRule businessValidationRule { get; set; }
        public bool IsSuccess { get; set; }
    }

}
