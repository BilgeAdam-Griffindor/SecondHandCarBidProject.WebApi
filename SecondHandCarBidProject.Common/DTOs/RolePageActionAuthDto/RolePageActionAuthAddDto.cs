using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.RolePageActionAuthDto
{
    public class RolePageActionAuthAddDto
    {
        public short RoleTypeId { get; set; }
        public short PageAuthTypeId { get; set; }
        public short ActionAuthTypeId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
