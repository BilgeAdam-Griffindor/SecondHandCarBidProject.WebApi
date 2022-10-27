using SecondHandCarBidProject.Common.DTOs;
using SecondHandCarBidProject.Common.DTOs.CarBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface ICarBrandDAL
    {
        public Task<ResponseModel<CarBrandListPageDTO>> List(int page = 1, int itemPerPage = 100);

        public Task<ResponseModel<bool>> AddPost(CarBrandAddDTO dto);

        public Task<ResponseModel<CarBrandUpdatePageDTO>> UpdateGet(short id);

        public Task<ResponseModel<bool>> UpdatePost(CarBrandUpdateSendDTO dto);

        public Task<ResponseModel<bool>> Delete(int brandId);
    }
}
