using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DapperPerfTest.EFCore5.Scaffold;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DapperPerfTest.PerfTest
{
    [SimpleJob(RuntimeMoniker.Net60, invocationCount: 10000)]
    public class TimeToFirstQueryEF5
    {
        private IHost efHost = null!;

        [GlobalSetup]
        public void Setup()
        {
            this.efHost = DapperPerfTest.EFCore5.Program.CreateHostBuilder().Build();
        }

        [Benchmark]
        public void EFCore5()
        {
            using var scope = this.efHost.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<NorthwindContext>();
            context.Customers.Add(new Customer { CustomerId = Guid.NewGuid().ToString() });
        }
    }
}
