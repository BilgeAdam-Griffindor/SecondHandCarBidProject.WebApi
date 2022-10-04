using SecondHandCarBidProject.Log.Abstract;
using SecondHandCarBidProject.Logs.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Log.Concrete
{
    public class LoggerFactory<T>
        where T : class
    {
        public enum LoggerType
        {
            MongoDatabaseLogger = 1,
            MssqlDataBaseLogger=2,
            FileLogger = 3,
        }
        public async Task FactoryMethod(LoggerType logType, T data)
        {
            ILogger<T> log = null;
            switch (logType)
            {
                case LoggerType.MongoDatabaseLogger:
                    log = new MongoDatabaseLog<T>();
                    break;
                case LoggerType.MssqlDataBaseLogger:
                    log = new MssqlDatabaseLog<T>();
                    break;
                default:
                    break;
            }
            await log.DataLog(data);
        }
    }
}
