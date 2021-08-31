using System.Data;
using System.Threading.Tasks;
using DapperPerfTest.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DapperPerfTest.Dapper
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            return CreateHostBuilder(args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return HostBuilderFactory.Create(args).ConfigureServices(_ => _
                .AddTransient<IDbConnection>(sp =>
                {
                    var config = sp.GetRequiredService<IConfiguration>();
                    return new SqlConnection(config.GetConnectionString("Sql"));
                }));
        }
    }
}
