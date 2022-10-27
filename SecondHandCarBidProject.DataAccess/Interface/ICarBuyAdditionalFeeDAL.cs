using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.CarBuyAdditionalFee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface ICarBuyAdditionalFeeDAL
    {
        public Task<ResponseModel<CarBuyAdditionalFeeListPageDTO>> List(int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<CarBuyAdditionalFeeAddPageDTO>> AddGet();

        public Task<ResponseModel<bool>> AddPost(CarBuyAdditionalFeeAddSendDTO dto);

        public Task<ResponseModel<bool>> Delete(Guid id, Guid modifiedBy);
    }
}
