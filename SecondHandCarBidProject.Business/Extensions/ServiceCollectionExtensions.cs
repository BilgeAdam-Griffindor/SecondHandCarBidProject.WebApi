using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondHandCarBidProject.DataAccess.Concrete;
using SecondHandCarBidProject.DataAccess.Concrete.Token;
using SecondHandCarBidProject.DataAccess.Interface;
using SecondHandCarBidProject.DataAccess.Interface.Token;
using SecondHandCarBidProject.DataAccess.Mongo;
using SecondHandCarBidProject.DataAccess.Mongo.Abstract;
using SecondHandCarBidProject.DataAccess.Mongo.Concrete;

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
            //services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<IAuthDAL, AuthDAL>();
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
