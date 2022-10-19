using Microsoft.Extensions.Options;
using SecondHandCarBidProject.DataAccess.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.Concrete;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Abstract;
using SecondHandCarBidProject.Logs.Abstract;
using SecondHandCarBidProject.Logs.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Log.Concrete
{
    public class LoggerFactoryMethod<T> : ILoggerFactoryMethod<T>
        where T : class,ILogEntity
    {
        IMongoLog<T> mongolog;
        IOptions<MongoSettings> options;
        public LoggerFactoryMethod()
        {

        }
        public LoggerFactoryMethod(IMongoLog<T> _mongoLog,IOptions<MongoSettings> _options)
        {
            mongolog = _mongoLog;
            options = _options;
        }
        public enum LoggerType
        {
            MongoDatabaseLogger = 1,
            FileLogger = 3,
        }
        public async Task FactoryMethod(LoggerType logType, T data)
        {
            ILoggerExtension<T> log = null;
            switch (logType)
            {
                case LoggerType.MongoDatabaseLogger:
                    log = new MongoDatabaseLog<T>(mongolog);
                    break;
                case LoggerType.FileLogger:
                    log = new FileLogger<T>();
                    break;
                default:
                    log = new FileLogger<T>();
                    break;
            }
            await log.DataLog(data);
        }
    }
}
