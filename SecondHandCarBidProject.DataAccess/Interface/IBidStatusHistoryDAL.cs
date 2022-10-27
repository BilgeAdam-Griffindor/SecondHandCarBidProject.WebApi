using SecondHandCarBidProject.Common.DTOs.BidOffer;
using SecondHandCarBidProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondHandCarBidProject.Common.DTOs.BidStatusHistory;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IBidStatusHistoryDAL
    {
        public Task<ResponseModel<BidStatusHistoryListPageDTO>> List(int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<BidStatusHistoryAddPageDTO>> AddGet();

        public Task<ResponseModel<bool>> AddPost(BidStatusHistoryAddSendDTO dto);

        public Task<ResponseModel<bool>> Delete(Guid id);
    }
}
