using SecondHandCarBidProject.Common.DTOs.BidCorporation;
using SecondHandCarBidProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondHandCarBidProject.Common.DTOs.CarBrand;
using SecondHandCarBidProject.Common.DTOs.BidResult;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IBidResultDAL
    {
        public Task<ResponseModel<BidResultListPageDTO>> List(int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<BidResultAddPageDTO>> AddGet();

        public Task<ResponseModel<bool>> AddPost(BidResultAddSendDTO dto);

        public Task<ResponseModel<BidResultUpdatePageDTO>> UpdateGet(Guid id);

        public Task<ResponseModel<bool>> UpdatePost(BidResultUpdateSendDTO dto);

        public Task<ResponseModel<bool>> Delete(Guid id, Guid modifiedBy);
    }
}
