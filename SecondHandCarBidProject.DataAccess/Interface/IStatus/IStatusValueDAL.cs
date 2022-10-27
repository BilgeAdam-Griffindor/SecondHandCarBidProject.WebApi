using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.StatusValueDTO;
using SecondHandCarBidProject.Common.DTOs.StatusValueDTO.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface.IStatus
{
    public interface IStatusValueDAL
    {
        public Task<ResponseModel<StatusValueListDto>> List(int page = 1, int itemPerPage = 10);
        public Task<ResponseModel<StatusValueAddGetDto>> AddGet();

        public Task<ResponseModel<bool>> Add(StatusValueAddDto statusValueAddDto);
        public Task<ResponseModel<StatusValueUpdateGetDto>> UpdateGet(int id);

        public Task<ResponseModel<bool>> Update(StatusValueUpdateDto statusValueUpdateDto);

        public Task<ResponseModel<bool>> Delete(int id);
    }
}
