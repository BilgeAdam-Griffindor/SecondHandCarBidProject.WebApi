using SecondHandCarBidProject.DataAccess.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Logs.Concrete
{
    public class MssqlDatabaseLog<T>:ILoggerExtension<T>
        where T : class, ILogEntity
    {
        public async Task DataLog(T data)
        {
            throw new NotImplementedException();
        }
    }
}
