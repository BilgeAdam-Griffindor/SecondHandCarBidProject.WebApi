using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondHandCarBidProject.DataAccess.Concrete;
using SecondHandCarBidProject.DataAccess.Interface;
using SecondHandCarBidProject.DataAccess.Mongo;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.Concrete;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Concrete;
using SecondHandCarBidProject.Logs.Abstract;

namespace SecondHandCarBidProject.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Settings
            services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));
            //DPI
            services.AddSingleton<IMongoLog, MongoLog>();
            services.AddSingleton<ILoggerFactoryMethod, LoggerFactoryMethod>();
            services.AddSingleton<IMongoEmailPasswordToken, MongoEmailPasswordToken>();
            services.AddScoped<IUserDAL, UserDAL>();

        }
    }
}
