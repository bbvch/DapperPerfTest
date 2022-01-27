using System;
using System.Data;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.Extensions.DependencyInjection;

namespace DapperPerfTest.PerfTest
{
    [SimpleJob(RuntimeMoniker.Net60, invocationCount: 1000)]
    public abstract class PerfTestBase : IDisposable
    {
        private IServiceScope scope = null!;

        protected IDbConnection DbConnection { get; set; } = null!;

        protected EFCore5.Scaffold.NorthwindContext EF5Context { get; set; } = null!;

        protected EFCore6.Scaffold.NorthwindContext EF6Context { get; set; } = null!;

        [GlobalSetup(Targets = new[] { "Dapper" })]
        public void DapperSetup()
        {
            this.scope = Dapper.Program.CreateHostBuilder().Build().Services.CreateScope();
            this.DbConnection = this.scope.ServiceProvider.GetRequiredService<IDbConnection>();
        }

        [GlobalSetup(Targets = new[] { "EFCore5" })]
        public void EFCore5Setup()
        {
            this.scope = EFCore5.Program.CreateHostBuilder().Build().Services.CreateScope();
            this.EF5Context = this.scope.ServiceProvider.GetRequiredService<EFCore5.Scaffold.NorthwindContext>();
        }

        [GlobalSetup(Targets = new[] { "EFCore6" })]
        public void EFCore6Setup()
        {
            this.scope = EFCore6.Program.CreateHostBuilder(EFCore6.Program.Mode.Traditional).Build().Services
                .CreateScope();
            this.EF6Context = this.scope.ServiceProvider.GetRequiredService<EFCore6.Scaffold.NorthwindContext>();
        }

        [GlobalSetup(Targets = new[] { "EFCore6Compiled" })]
        public void EFCore6CompiledSetup()
        {
            this.scope = EFCore6.Program.CreateHostBuilder(EFCore6.Program.Mode.Compiled).Build().Services
                .CreateScope();
            this.EF6Context = this.scope.ServiceProvider.GetRequiredService<EFCore6.Scaffold.NorthwindContext>();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.scope.Dispose();
                this.DbConnection?.Dispose();
                this.EF5Context?.Dispose();
                this.EF6Context?.Dispose();
            }
        }
    }
}
