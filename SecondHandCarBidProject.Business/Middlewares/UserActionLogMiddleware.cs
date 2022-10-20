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
        private IUserRequestLogCatcher logCatcher;
        public UserActionLogMiddleware(RequestDelegate next,IOptions<MongoSettings> options,IUserRequestLogCatcher _logCatcher)
        {
           _next = next;
            logCatcher = _logCatcher;

        }
        public async Task Invoke(HttpContext httpContext)
        {
            await logCatcher.UserRequestLogAddToMongoDb(httpContext);
            await _next(httpContext);
        }
    }
  
}
