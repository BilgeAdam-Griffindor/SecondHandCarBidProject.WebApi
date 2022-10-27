using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.RolePageActionAuthDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface.IAuthorization
{
    public interface IRolePageActionAuthDAL
    {
        public Task<ResponseModel<RolePageActionAuthListDto>> List(int page = 1, int itemPerPage = 10);

        public Task<ResponseModel<RolePageActionAuthAddGetDTO>> AddGet();
        public Task<ResponseModel<bool>> AddPost(RolePageActionAuthAddDto pageAuthTypeAddDTO);
    }
}
