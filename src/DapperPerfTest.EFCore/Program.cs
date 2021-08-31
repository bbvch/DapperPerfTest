using System.Threading.Tasks;
using DapperPerfTest.Common;
using DapperPerfTest.EFCore.Scaffold;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DapperPerfTest.EFCore
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
                .AddDbContextFactory<NorthwindContext>());
        }
    }
}
