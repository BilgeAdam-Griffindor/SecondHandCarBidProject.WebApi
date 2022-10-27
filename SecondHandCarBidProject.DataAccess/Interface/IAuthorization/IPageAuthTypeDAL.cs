using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.PageAuthTypeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface.IAuthorization
{
    public interface IPageAuthTypeDal
    {
        public Task<ResponseModel<PageAuthTypeListDTO>> List(int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<bool>> AddGet(PageAuthTypeAddDTO pageAuthTypeAddDTO);

        //public Task<ResponseModel<bool>> AddPost(BidCorporationAddSendDTO dto);

        //public Task<ResponseModel<bool>> Delete(Guid bidId, int corporationId, Guid modifiedBy);
    }
}
