using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Logs.Concrete
{
    public class MssqlDatabaseLog:ILogger
    {
        public async Task DataLog(MongoLogModel data)
        {
            throw new NotImplementedException();
        }
    }
}
