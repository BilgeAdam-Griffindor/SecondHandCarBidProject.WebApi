using Microsoft.AspNetCore.Http;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Concrete;
using SecondHandCarBidProject.Logs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Logs.Concrete
{
    public class UserRequestLogCatcher : IUserRequestLogCatcher
    {
        MongoUserRequestLogModel LogModel;
        ILoggerFactoryMethod<MongoUserRequestLogModel> loggerFactoryMethod;
        public UserRequestLogCatcher(ILoggerFactoryMethod<MongoUserRequestLogModel> _loggerFactoryMethod)
        {
            LogModel = new MongoUserRequestLogModel();
            loggerFactoryMethod = _loggerFactoryMethod;
        }
        public async Task UserRequestLogAddToMongoDb(HttpContext httpContext)
        {
            MongoUserRequestLogModel mongoLogModel = new MongoUserRequestLogModel();
            mongoLogModel.IpAddress = httpContext.Connection.RemoteIpAddress.ToString();
            mongoLogModel.CreatedDate = DateTime.Now;
            mongoLogModel.ActionType = httpContext.Request.Method;
            mongoLogModel.Url = httpContext.Request.Path;
            mongoLogModel.BrowserType = httpContext.Request.Headers["User-Agent"].ToString();
            await loggerFactoryMethod.FactoryMethod(LoggerFactoryMethod<MongoUserRequestLogModel>.LoggerType.MongoUserRequestLogger, mongoLogModel);
          
        }
    }
}
