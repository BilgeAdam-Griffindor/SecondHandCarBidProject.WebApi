using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.CarBuyStatusHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface ICarBuyStatusHistoryDAL
    {
        public Task<ResponseModel<CarBuyStatusHistoryListPageDTO>> List(int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<CarBuyStatusHistoryAddPageDTO>> AddGet();

        public Task<ResponseModel<bool>> AddPost(CarBuyStatusHistoryAddSendDTO dto);

        public Task<ResponseModel<bool>> Delete(Guid id);
    }
}
