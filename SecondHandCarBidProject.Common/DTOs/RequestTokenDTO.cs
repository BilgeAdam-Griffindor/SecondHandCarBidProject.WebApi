using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs
{
    public class RequestTokenDTO
    {
        public Guid UserId { get; set; }
        public string TokenFor { get; set; }
    }
}
