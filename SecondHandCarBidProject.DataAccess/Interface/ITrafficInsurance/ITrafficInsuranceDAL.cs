using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.TrafficInsuranceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface.ITrafficInsurance
{
    public interface ITrafficInsuranceDAL
    {
        public Task<ResponseModel<TrafficInsuranceListDto>> List(int page = 1, int itemPerPage = 10);
        public Task<ResponseModel<TrafficInsuranceAddGetDto>> AddGet();

        public Task<ResponseModel<bool>> Add(TrafficInsuranceAddDto statusValueAddDto);
        public Task<ResponseModel<TrafficInsuranceUpdateGetDto>> UpdateGet(Guid id);

        public Task<ResponseModel<bool>> Update(TrafficInsuranceUpdateDto statusValueUpdateDto);

        public Task<ResponseModel<bool>> Delete(Guid id);
    }
}
