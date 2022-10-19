using Newtonsoft.Json;
using SecondHandCarBidProject.DataAccess.Abstract;
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
    /// <summary>
    /// This class add log data to .txt file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FileLogger<T> : ILoggerExtension<T> where T : class, ILogEntity
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public FileLogger()
        {
            LogConfig logConfig = new LogConfig();
        } /// <summary>
          /// This method takes one paremater. also converting data as a json and adding to .txt file
          /// </summary>
          /// <param name="data"></param>
          /// <returns></returns>
        public Task DataLog(T data)
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
