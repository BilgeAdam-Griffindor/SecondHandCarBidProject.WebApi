using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceTrafficInsuranceCarComponentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance
{
    public interface ITrafficInsuranceTrafficInsuranceCarComponentDAL
    {
        public Task<ResponseModel<TrafficInsuranceTrafficInsuranceCarComponentAddDto>> Add();
        public Task<TrafficInsuranceTrafficInsuranceCarComponentListDto> List();
    }
}
