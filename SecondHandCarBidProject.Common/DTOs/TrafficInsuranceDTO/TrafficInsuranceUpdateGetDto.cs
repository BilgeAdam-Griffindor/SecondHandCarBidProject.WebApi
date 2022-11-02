using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceDTO.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.TrafficInsuranceDTO
{
    public class TrafficInsuranceUpdateGetDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public decimal Cost { get; set; }
        public List<TrafficInsuranceTempCar> trafficInsuranceTempCars { get; set; }
    }
}
