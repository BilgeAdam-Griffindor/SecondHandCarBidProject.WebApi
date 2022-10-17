using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs
{
    public class GetTokenInfoDTO
    {
        public string Id { get; set; }

        public Guid UserId { get; set; }

        public string TokenFor { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
