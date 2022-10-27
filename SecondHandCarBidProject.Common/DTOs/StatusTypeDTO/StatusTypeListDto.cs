using SecondHandCarBidProject.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.StatusTypeDTO
{
    public class StatusTypeListDto
    {
        public List<StatusTypeDto> statusTypeListDtos { get; set; }
        public int maxPages { get; set; }
    }
}
