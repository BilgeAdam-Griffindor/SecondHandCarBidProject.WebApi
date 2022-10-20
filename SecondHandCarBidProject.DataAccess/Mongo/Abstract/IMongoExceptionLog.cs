using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Mongo.Abstract
{
    public interface IMongoExceptionLog<T> where T : class
    {
        Task<bool> LogToMongo(T log);
    }
}
