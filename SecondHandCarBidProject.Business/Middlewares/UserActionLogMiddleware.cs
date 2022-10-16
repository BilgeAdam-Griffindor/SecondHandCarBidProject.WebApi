using DnsClient.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SecondHandCarBidProject.DataAccess.Mongo;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Abstract;
using SecondHandCarBidProject.Log.Concrete;
using SecondHandCarBidProject.Logs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Business.Middlewares
{
    public class UserActionLogMiddleware
    {
        private readonly RequestDelegate _next;
        private ILoggerFactoryMethod<MongoLogModel> loggerFactoryMethod;
        public UserActionLogMiddleware(RequestDelegate next, ILoggerFactoryMethod<MongoLogModel> _loggerfactorymethod,IOptions<MongoSettings> options)
        {
           _next = next;
            loggerFactoryMethod = _loggerfactorymethod;

        }
        public async Task Invoke(HttpContext httpContext)
        {
            MongoLogModel mongoLogModel = new MongoLogModel();
            mongoLogModel.IpAddress= httpContext.Connection.RemoteIpAddress.ToString();
            mongoLogModel.CreatedDate= DateTime.Now;
            mongoLogModel.ActionType= httpContext.Request.Method;
            mongoLogModel.Url= httpContext.Request.Path;
            mongoLogModel.BrowserType= httpContext.Request.Headers["User-Agent"].ToString();
            var result =  loggerFactoryMethod.FactoryMethod(LoggerFactoryMethod<MongoLogModel>.LoggerType.FileLogger, mongoLogModel);
            await _next(httpContext);
        }
    }
  
}
