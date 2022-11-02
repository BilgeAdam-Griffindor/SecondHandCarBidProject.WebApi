using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceCarComponentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance
{
    public interface ITrafficInsuranceCarComponentDAL
    {
        public Task<ResponseModel<TrafficInsuranceCarComponentListDto>> List(int page = 1, int itemPerPage = 10);

        public Task<ResponseModel<bool>> Add(TrafficInsuranceCarComponentAddDto trafficInsuranceCarComponentAddDto);

        public Task<ResponseModel<bool>> Update(TrafficInsuranceCarComponentUpdateDto trafficInsuranceCarComponentUpdateDto);

        public Task<ResponseModel<bool>> Delete(short id);
    }
}
