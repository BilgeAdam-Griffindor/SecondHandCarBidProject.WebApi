using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Mongo.Abstract
{
    public interface IMongoUserRequestLog<T> where T :class
    {
        Task<bool> AddUserRequestLogToMongo(T log);
    }
}
