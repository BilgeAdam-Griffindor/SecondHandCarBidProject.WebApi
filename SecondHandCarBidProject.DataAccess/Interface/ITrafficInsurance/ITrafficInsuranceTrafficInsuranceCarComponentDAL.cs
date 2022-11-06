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
        public Task<ResponseModel<bool>> Add(TrafficInsuranceTrafficInsuranceCarComponentAddDto titiccad);
        public Task<ResponseModel<TrafficInsuranceTrafficInsuranceCarComponentListDto>> List(int page = 1, int itemPerPage = 10);
    }
}
