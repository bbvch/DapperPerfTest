using System;
using System.Linq;
using System.Threading.Tasks;
using DapperPerfTest.Common;
using DapperPerfTest.EFCore6.Scaffold;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DapperPerfTest.EFCore6
{
    public static class Program
    {
        public enum Mode
        {
            Traditional,
            Compiled
        }

        public static Task Main(string[] args)
        {
            return CreateHostBuilder(Mode.Traditional, args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(Mode mode, params string[] args)
        {
            return HostBuilderFactory.Create(args).ConfigureServices(_ => _
                .AddDbContext<NorthwindContext>(o =>
                {
                    o.UseSqlServer("Name=ConnectionStrings:Sql");
                    if (mode == Mode.Compiled)
                    {
                        o.UseModel(NorthwindContextModel.Instance);
                    }
                }));
        }
    }
}
