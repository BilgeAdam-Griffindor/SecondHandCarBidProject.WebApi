using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Mongo.Concrete
{
    public class MongoExceptionLog<T> : IMongoExceptionLog<T> where T : class
    {
        IMongoCollection<T> _mongoLog;

        public MongoExceptionLog(IOptions<MongoSettings> MongoSettings)
        {
            var mongoSettings = MongoClientSettings.FromConnectionString(MongoSettings.Value.ConnectionString);
            mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(mongoSettings);
            var logForMongoDB = client.GetDatabase(MongoSettings.Value.DatabaseName);
            _mongoLog = logForMongoDB.GetCollection<T>(MongoSettings.Value.WebApiExceptionLogCollection);
        }
        public async Task<bool> LogToMongo(T log)
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
