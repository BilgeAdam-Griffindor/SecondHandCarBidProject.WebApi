using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondHandCarBidProject.DataAccess.Concrete;
using SecondHandCarBidProject.DataAccess.Concrete.Authorization;
using SecondHandCarBidProject.DataAccess.Concrete.Status;
using SecondHandCarBidProject.DataAccess.Concrete.Token;
using SecondHandCarBidProject.DataAccess.Context;
using SecondHandCarBidProject.DataAccess.Interface;
using SecondHandCarBidProject.DataAccess.Interface.IAuthorization;
using SecondHandCarBidProject.DataAccess.Interface.IStatus;
using SecondHandCarBidProject.DataAccess.Interface.Token;
using SecondHandCarBidProject.DataAccess.Mongo;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.Concrete;
using SecondHandCarBidProject.DataAccess.Mongo.MongoModels;
using SecondHandCarBidProject.Log.Concrete;
using SecondHandCarBidProject.Logs.Abstract;
using SecondHandCarBidProject.Logs.Concrete;

namespace SecondHandCarBidProject.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Settings
            services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));
            //DPI
            //services.AddScoped<IUserDAL, UserDAL>();
            services.AddSingleton<IUserRequestLogCatcher, UserRequestLogCatcher>();
            services.AddScoped<ILogCatcherMongoLog, LogCatcherMongoLog>();
            services.AddSingleton<DapperContext>();
            services.AddScoped<IAuthDAL, AuthDAL>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddSingleton<IMongoUserRequestLog<MongoUserRequestLogModel>, MongoUserRequestLog<MongoUserRequestLogModel>>();
            services.AddSingleton<IMongoExceptionLog<MongoExceptionLogModel>, MongoExceptionLog<MongoExceptionLogModel>>();
            services.AddSingleton(typeof(ILoggerFactoryMethod<>), typeof(LoggerFactoryMethod<>));
            services.AddSingleton<IMongoEmailPasswordToken, MongoEmailPasswordToken>();
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<IBidCorporationDAL, BidCorporationDAL>();
            services.AddScoped<IAdressInfoDAL, AdressInfoDAL>();
            services.AddScoped<IPageAuthTypeDal, PageAuthTypeDAL>();
            services.AddScoped<IRolePageActionAuthDAL, RolePageActionAuthDAL>();
            services.AddScoped<IRoleTypeDAL, RoleTypeDAL>();
            services.AddScoped<IStatusTypeDAL, StatusTypeDAL>();
            services.AddScoped<IStatusValueDAL, StatusValueDAL>();
            services.AddScoped<IBidDAL, BidDAL>();

        }
    }
}
