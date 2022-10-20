using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Mongo.Concrete
{
    public class MongoUserRequestLog<T> : IMongoUserRequestLog<T>
        where T:class
    {
        IMongoCollection<T> _mongoLog;
       
        public MongoUserRequestLog(IOptions<MongoSettings> MongoSettings)
        {
            var mongoSettings = MongoClientSettings.FromConnectionString(MongoSettings.Value.ConnectionString);
            mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(mongoSettings);
            var logForMongoDB = client.GetDatabase(MongoSettings.Value.DatabaseName);
            _mongoLog = logForMongoDB.GetCollection<T>(MongoSettings.Value.WebApiAdmingRequestLogCollection);
        }
        public async Task<bool> AddUserRequestLogToMongo(T log)
        {
            try
            {
                await _mongoLog.InsertOneAsync(log);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
