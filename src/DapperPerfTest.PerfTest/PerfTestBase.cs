using System.Data;
using DapperPerfTest.EFCore.Scaffold;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DapperPerfTest.PerfTest
{
    public abstract class PerfTestBase
    {
        protected PerfTestBase()
        {
            var args = new[] { Program.ConnectionString };
            this.DbConnection = Dapper.Program.CreateHostBuilder(args).Build().Services.GetRequiredService<IDbConnection>();
            this.EfContext = EFCore.Program.CreateHostBuilder(args).Build().Services
                .GetRequiredService<IDbContextFactory<NorthwindContext>>().CreateDbContext();
        }

        protected IDbConnection DbConnection { get; }

        protected NorthwindContext EfContext { get; }
    }
}
