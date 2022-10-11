using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SecondHandCarBidProject.DataAccess.Mongo;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.Concrete;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Log.Concrete
{
    public class MongoDatabaseLog : ILoggerExtension 
    {
        IMongoLog mongoLog;
        public MongoDatabaseLog(IMongoLog mongoLog)
        {
            this.mongoLog = mongoLog;
        }
        public async Task DataLog(MongoLogModel data)
        {

            await mongoLog.AddLogToMongo(data);
        }
    }
}
