using System.Data;
using BenchmarkDotNet.Attributes;
using DapperPerfTest.EFCore.Scaffold;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DapperPerfTest.PerfTest
{
    public class TimeToFirstQuery
    {
        private readonly IHost dapperHost;
        private readonly IHost efHost;

        public TimeToFirstQuery()
        {
            var args = new[] { Program.ConnectionString };
            this.dapperHost = DapperPerfTest.Dapper.Program.CreateHostBuilder(args).Build();
            this.efHost = EFCore.Program.CreateHostBuilder(args).Build();
        }

        [Benchmark(Baseline = true)]
        public IDbConnection Dapper()
        {
            return this.dapperHost.Services.GetRequiredService<IDbConnection>();
        }

        [Benchmark]
        public DbContext EfCore()
        {
            var factory = this.efHost.Services.GetRequiredService<IDbContextFactory<NorthwindContext>>();
            return factory.CreateDbContext();
        }
    }
}
