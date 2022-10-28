using SecondHandCarBidProject.Common.DTOs.StatusValueDTO.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.StatusValueDTO
{
    public class StatusValueUpdateGetDto
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public int StatusTypeId { get; set; }
        public List<StatusTypeTempDto> statusTypeTempDtos { get; set; }
    }
}
