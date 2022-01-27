using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperPerfTest.Dapper
{
    public class DapperContext
    {
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("Sql");
        }

        public IDbConnection Connection =>
            new SqlConnection(this.connectionString);
    }
}
