using SecondHandCarBidProject.Common.DTOs.RolePageActionAuthDto.TempDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.RolePageActionAuthDto
{
    public class RolePageActionAuthAddGetDTO
    {
        public List<RoleTypeTempAddGetDto> roleTypelistDtos { get; set; }
        public List<PageAuthTypeTempAddGetDto> pageauthTypelistDtos { get; set; }
        public List<ActionAuthTypeTempAddGetDto> actionauthTypelistDtos { get; set; }
    }
}
