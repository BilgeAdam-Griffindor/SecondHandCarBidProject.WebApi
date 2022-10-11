using Newtonsoft.Json;
using SecondHandCarBidProject.DataAccess.Mongo.Concrete;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Abstract;
using SecondHandCarBidProject.Logs.Nlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Logs.Concrete
{
    public class FileLogger : ILoggerExtension
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public FileLogger()
        {
            LogConfig logConfig = new LogConfig();
        }
        public Task DataLog(MongoLogModel data)
        {
            string message = null;
            try
            {
                message = JsonConvert.SerializeObject(data, Formatting.Indented,
                   new JsonSerializerSettings
                   {
                       PreserveReferencesHandling = PreserveReferencesHandling.Objects
                   });
                Logger.Info(message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Hata Oluştu " + DateTime.Now + " " + message);
            }
            return Task.CompletedTask;
        }
    }
}
