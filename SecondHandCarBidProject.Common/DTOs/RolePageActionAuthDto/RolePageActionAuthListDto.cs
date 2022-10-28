using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.RolePageActionAuthDto
{
    public class RolePageActionAuthListDto
    {
        public List<RolePageActionAuthDTO> pageAuthTypeDtos { get; set; }
        public int maxPages { get; set; }

        
    }
}
