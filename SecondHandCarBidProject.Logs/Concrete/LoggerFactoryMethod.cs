using Microsoft.Extensions.Options;
using MongoDB.Driver;
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
        
        IOptions<MongoSettings> options;
        public LoggerFactoryMethod()
        {

        }
        public LoggerFactoryMethod(IOptions<MongoSettings> _options)
        {
           
            options = _options;
        }
        public enum LoggerType
        {
            MongoUserRequestLogger = 1,
            MongoExceptionLogger=2,
            FileLogger = 3,
        }
        public async Task FactoryMethod(LoggerType logType, T data)
        {
            ILoggerExtension<T> log = null;
            switch (logType)
            {
                case LoggerType.MongoUserRequestLogger:
                    log = new MongoUserRequestLogger<T>(options);
                    break;
                case LoggerType.MongoExceptionLogger:
                    log = new MongoExceptionLogger<T>(options);
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
