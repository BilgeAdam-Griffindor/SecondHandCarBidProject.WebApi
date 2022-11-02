using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.TrafficInsuranceDTO
{
    public class TrafficInsuranceAddDto
    {
        public Guid CarId { get; set; }
        public decimal Cost { get; set; }
        public Guid CreatedId { get; set; }
    }
}
