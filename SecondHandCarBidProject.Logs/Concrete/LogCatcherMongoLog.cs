using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Concrete;
using SecondHandCarBidProject.Logs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Logs.Concrete
{
    public class LogCatcherMongoLog : ILogCatcherMongoLog
    {
        MongoExceptionLogModel LogModel;
        ILoggerFactoryMethod<MongoExceptionLogModel> loggerFactoryMethod;
        public LogCatcherMongoLog(ILoggerFactoryMethod<MongoExceptionLogModel> _loggerFactoryMethod)
        {
            LogModel = new MongoExceptionLogModel();
            loggerFactoryMethod = _loggerFactoryMethod;
        }

        public Task WriteLogWarning(Exception ex)
        {
            LogModel.Exception = ex.Message;
            LogModel.CreatedDate = DateTime.UtcNow;
            LogModel.LogType = (int)LogLevel.Type.Warning;
            loggerFactoryMethod.FactoryMethod(LoggerFactoryMethod<MongoExceptionLogModel>.LoggerType.MongoExceptionLogger, LogModel);
            return Task.CompletedTask;
        }
        public Task WriteLogInfo(Exception ex)
        {
            LogModel.Exception = ex.Message;
            LogModel.CreatedDate = DateTime.UtcNow;
            LogModel.LogType = (int)LogLevel.Type.Info;
            loggerFactoryMethod.FactoryMethod(LoggerFactoryMethod<MongoExceptionLogModel>.LoggerType.MongoExceptionLogger, LogModel);
            return Task.CompletedTask;
        }
        public Task WriteLogDebug(Exception ex)
        {
            LogModel.Exception = ex.Message;
            LogModel.CreatedDate = DateTime.UtcNow;
            LogModel.LogType = (int)LogLevel.Type.Debug;
            loggerFactoryMethod.FactoryMethod(LoggerFactoryMethod<MongoExceptionLogModel>.LoggerType.MongoExceptionLogger, LogModel);
            return Task.CompletedTask;
        }
    }
}
