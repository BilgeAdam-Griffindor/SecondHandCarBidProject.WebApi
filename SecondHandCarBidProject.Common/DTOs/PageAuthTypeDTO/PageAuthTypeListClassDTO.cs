using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.PageAuthTypeDTO
{
    public class PageAuthTypeListClassDTO
    {
       public List<PageAuthTypeClassDto> pageAuthTypeDtos { get; set; }
       public int maxPages { get; set; }
    }
}
