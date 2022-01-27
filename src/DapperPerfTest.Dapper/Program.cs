using System.Threading.Tasks;
using DapperPerfTest.Common;
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

        public static IHostBuilder CreateHostBuilder(params string[] args)
        {
            return HostBuilderFactory.Create(args).ConfigureServices(_ => _
                .AddSingleton<DapperContext>()
                .AddScoped(sp => sp.GetRequiredService<DapperContext>().Connection));
        }
    }
}
