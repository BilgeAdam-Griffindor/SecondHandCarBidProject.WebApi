using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SecondHandCarBidProject.Log.Concrete.LoggerFactoryMethod;

namespace SecondHandCarBidProject.Logs.Abstract
{
    public interface ILoggerFactoryMethod
    {
        Task FactoryMethod(LoggerType logType, MongoLogModel data);
    }
}
