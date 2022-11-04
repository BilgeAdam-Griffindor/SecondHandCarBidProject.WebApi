using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.TrafficInsuranceTrafficInsuranceCarComponentDTO
{
    public class TrafficInsuranceTrafficInsuranceCarComponentAddDto
    {
        public Guid TrafficInsuranceId { get; set; }
        public short TrafficInsuranceCarComponentId { get; set; }
        public int StatusValueId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
