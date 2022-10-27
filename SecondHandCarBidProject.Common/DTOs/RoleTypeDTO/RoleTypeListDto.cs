using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.RoleTypeDTO
{
    public class RoleTypeListDto
    {
        public List<RoleTypeDto> roleTypeListDto { get; set; }
        public int maxPages { get; set; }
    }
}
