using Microsoft.Extensions.Options;
using SecondHandCarBidProject.DataAccess.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.Concrete;
using SecondHandCarBidProject.Log.Abstract;
using SecondHandCarBidProject.Logs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Logs.Concrete
{
    /// <summary>
    /// This class add user request log data to mongodb
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MongoExceptionLogger<T> : ILoggerExtension<T>
        where T : class, ILogEntity
    {
        
        IMongoExceptionLog<T> mongoLog;
        public MongoExceptionLogger(IOptions<MongoSettings> options)
        {
            mongoLog=new MongoExceptionLog<T>(options);
        }
        /// <summary>
        /// This method takes generic paramater as a T type data. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task DataLog(T data)
        {
            await mongoLog.LogToMongo(data);
        }
    }
}
