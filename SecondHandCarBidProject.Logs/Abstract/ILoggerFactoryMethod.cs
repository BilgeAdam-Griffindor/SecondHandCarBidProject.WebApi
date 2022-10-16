using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondHandCarBidProject.Log.Concrete;
using SecondHandCarBidProject.DataAccess.Abstract;

namespace SecondHandCarBidProject.Logs.Abstract
{
    public interface ILoggerFactoryMethod <T> where T : class, ILogEntity
    {
        Task FactoryMethod(LoggerFactoryMethod<T>.LoggerType logType, T data);
    }
}
