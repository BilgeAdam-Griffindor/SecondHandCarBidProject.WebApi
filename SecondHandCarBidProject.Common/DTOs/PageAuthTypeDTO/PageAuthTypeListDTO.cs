using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.PageAuthTypeDTO
{
    public record PageAuthTypeListDTO(
        List<PageAuthTypeDto> pageAuthTypeDtos,
        int maxPages)
    {
    }
}
