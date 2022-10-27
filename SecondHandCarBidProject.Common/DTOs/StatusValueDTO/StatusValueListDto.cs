using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.StatusValueDTO
{
    public class StatusValueListDto
    {
       public List<StatusValueDto> statusValueListDtos { get; set; }
       public int maxPages { get; set; }
    }
}
