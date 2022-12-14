using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.BidCorporation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IBidCorporationDAL
    {
        public Task<ResponseModel<BidCorporationListPageDTO>> List(int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<BidCorporationAddPageDTO>> AddGet();

        public Task<ResponseModel<bool>> AddPost(BidCorporationAddSendDTO dto);

        public Task<ResponseModel<bool>> Delete(Guid bidId, int corporationId, Guid modifiedBy);
    }
}
