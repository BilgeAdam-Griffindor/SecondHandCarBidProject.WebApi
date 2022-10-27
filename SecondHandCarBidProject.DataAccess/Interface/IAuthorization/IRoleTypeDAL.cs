using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.RoleTypeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface.IAuthorization
{
    public interface IRoleTypeDAL
    {
        public Task<ResponseModel<RoleTypeListDto>> List(int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<bool>> Add(RoleTypeAddDto roleTypeAddDto);

        public Task<ResponseModel<bool>> Update(RoleTypeUpdateDto roleTypeUpdateDto);

        public Task<ResponseModel<bool>> Delete(short id);
    }
}
