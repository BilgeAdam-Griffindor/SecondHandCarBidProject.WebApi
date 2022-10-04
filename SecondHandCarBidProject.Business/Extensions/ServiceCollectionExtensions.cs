using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondHandCarBidProject.DataAccess.Concrete;
using SecondHandCarBidProject.DataAccess.Interface;

namespace SecondHandCarBidProject.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserDAL, UserDAL>();

        }
    }
}
