using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.Concrete;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Abstract;
using SecondHandCarBidProject.Logs.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Log.Concrete
{
    public class LoggerFactory
    {
        public enum LoggerType
        {
            MongoDatabaseLogger = 1,
            MssqlDataBaseLogger=2,
            FileLogger = 3,
        }
        public async Task FactoryMethod(LoggerType logType, MongoLogModel data,IMongoLog mongo)
        {
            ILogger log = null;
            switch (logType)
            {
                case LoggerType.MongoDatabaseLogger:
                    log = new MongoDatabaseLog(mongo);
                    break;
                case LoggerType.MssqlDataBaseLogger:
                    log = new MssqlDatabaseLog();
                    break;
                case LoggerType.FileLogger:
                    log = new FileLogger();
                    break;
                default:
                    break;
            }
            await log.DataLog(data);
        }
    }
}
