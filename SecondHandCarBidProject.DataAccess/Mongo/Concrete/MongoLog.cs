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
    public class MongoLog : IMongoLog
    {
        IMongoCollection<MongoLogModel> _mongoLog;
        public MongoLog(IOptions<MongoSettings> MongoSettings)
        {
            var mongoSettings = MongoClientSettings.FromConnectionString(MongoSettings.Value.ConnectionString);
            mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(mongoSettings);
            var logForMongoDB = client.GetDatabase(MongoSettings.Value.DatabaseName);
            _mongoLog = logForMongoDB.GetCollection<MongoLogModel>(MongoSettings.Value.CollectionName);
        }
        public async Task<bool> AddLogToMongo(MongoLogModel log)
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
