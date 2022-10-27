using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.StatusTypeDTO;
using SecondHandCarBidProject.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface.IStatus
{
    public interface IStatusTypeDAL
    {
        public Task<ResponseModel<StatusTypeListDto>> List(int page = 1, int itemPerPage = 10);

        public Task<ResponseModel<bool>> Add(StatusTypeAddDTO statusTypeAddDto);

        public Task<ResponseModel<bool>> Update(StatusTypeUpdateDto statusTypeUpdateDto);

        public Task<ResponseModel<bool>> Delete(short id);
    }
}
