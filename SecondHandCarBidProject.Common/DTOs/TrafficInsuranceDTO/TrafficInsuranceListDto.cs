using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.TrafficInsuranceDTO
{
    public class TrafficInsuranceListDto
    {
        public List<TrafficInsuranceDto> trafficInsuranceListDtos { get; set; }
        public int maxPages { get; set; }
    }
}
