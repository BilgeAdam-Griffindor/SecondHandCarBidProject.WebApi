using SecondHandCarBidProject.Common.DTOs.BidOffer;
using SecondHandCarBidProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondHandCarBidProject.Common.DTOs.CarBuy;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface ICarBuyDAL
    {
        public Task<ResponseModel<CarBuyListPageDTO>> List(short? brandId = null, int? modelId = null, int? statusId = null, int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<CarDetailAddPageDTO>> AddGet();

        public Task<ResponseModel<bool>> AddPost(CarBuyAddSendDTO dto);

        public Task<ResponseModel<CarBuyUpdatePageDTO>> UpdateGet(Guid id);

        public Task<ResponseModel<bool>> UpdatePost(CarBuyUpdateSendDTO dto);

        public Task<ResponseModel<bool>> Delete(Guid id, Guid modifiedBy);
    }
}
