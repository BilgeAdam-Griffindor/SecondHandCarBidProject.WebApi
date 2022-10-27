using SecondHandCarBidProject.Common.DTOs.BidResult;
using SecondHandCarBidProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondHandCarBidProject.Common.DTOs.BidOffer;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IBidOfferDAL
    {
        public Task<ResponseModel<BidOfferListPageDTO>> List(int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<BidOfferAddPageDTO>> AddGet();

        public Task<ResponseModel<bool>> AddPost(BidOfferAddSendDTO dto);

        public Task<ResponseModel<BidOfferUpdatePageDTO>> UpdateGet(Guid id);

        public Task<ResponseModel<bool>> UpdatePost(BidOfferUpdateSendDTO dto);

        public Task<ResponseModel<bool>> Delete(Guid id, Guid modifiedBy);
    }
}
