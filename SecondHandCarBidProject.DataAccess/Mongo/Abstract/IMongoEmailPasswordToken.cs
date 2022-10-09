using SecondHandCarBidProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Mongo.Abstract
{
    public interface IMongoEmailPasswordToken
    {
        Task<string> AddToken(Guid userId, string tokenFor);

        Task<GetTokenInfoDTO> GetTokenInfo(string token);

        Task<bool> RemoveToken(string tokenId);

        Task<bool> RemoveExpiredTokens();
    }
}
