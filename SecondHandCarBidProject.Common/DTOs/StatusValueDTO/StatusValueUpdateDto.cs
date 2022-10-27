using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.StatusValueDTO
{
    public class StatusValueUpdateDto
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public int StatusTypeId { get; set; }
        
    }
}
