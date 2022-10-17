using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SecondHandCarBidProject.DataAccess.Abstract;
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
    /// <summary>
    /// This class add log data to mongodb
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MongoDatabaseLog<T> : ILoggerExtension<T> 
        where T : class, ILogEntity
    {
        IMongoLog<T> mongoLog;
        public MongoDatabaseLog(IMongoLog<T> mongoLog)
        {
            this.mongoLog = mongoLog;
        }
        /// <summary>
        /// This method takes generic paramater as a T type data. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task DataLog(T data)
        {

            await mongoLog.AddLogToMongo(data);
        }
    }
}
