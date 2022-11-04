using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceTrafficInsuranceCarComponentDTO;
using SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Concrete.TrafficInsurance
{
    public class TrafficInsuranceTrafficInsuranceCarComponentDAL : ITrafficInsuranceTrafficInsuranceCarComponentDAL
    {
        public Task<ResponseModel<TrafficInsuranceTrafficInsuranceCarComponentAddDto>> Add()
        {
            throw new NotImplementedException();
        }

        public Task<TrafficInsuranceTrafficInsuranceCarComponentListDto> List()
        {
            throw new NotImplementedException();
        }
    }
}
