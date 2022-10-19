using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MyConn");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
