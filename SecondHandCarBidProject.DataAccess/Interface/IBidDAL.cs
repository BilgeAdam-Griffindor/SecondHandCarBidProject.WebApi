using SecondHandCarBidProject.Common.DTOs.BidCorporation;
using SecondHandCarBidProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondHandCarBidProject.Common.DTOs.Bid;

namespace SecondHandCarBidProject.DataAccess.Interface
{
    public interface IBidDAL
    {
        public Task<ResponseModel<BidAddPageUserDTO>> AddGetUser(Guid userId, bool isCorporate);

        public Task<ResponseModel<bool>> AddPostUser(BidAddSendUserDTO dto);
    }
}
