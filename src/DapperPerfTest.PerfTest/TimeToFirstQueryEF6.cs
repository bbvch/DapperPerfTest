using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DapperPerfTest.EFCore6.Scaffold;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DapperPerfTest.PerfTest
{
    [SimpleJob(RuntimeMoniker.Net60, invocationCount: 10000)]
    public class TimeToFirstQueryEF6
    {
        private IHost efHost = null!;

        [ParamsAllValues]
        public DapperPerfTest.EFCore6.Program.Mode Mode { get; set; } = DapperPerfTest.EFCore6.Program.Mode.Traditional;

        [GlobalSetup]
        public void Setup()
        {
            this.efHost = DapperPerfTest.EFCore6.Program.CreateHostBuilder(this.Mode).Build();
        }

        [Benchmark]
        public void EFCore6()
        {
            using var scope = this.efHost.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<NorthwindContext>();
            context.Customers.Add(new Customer { CustomerId = Guid.NewGuid().ToString() });
        }
    }
}
