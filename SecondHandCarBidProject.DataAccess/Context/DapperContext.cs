using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SecondHandCarBidProject.DataAccess.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_configuration.GetConnectionString("MyConn"));
    }
}
