﻿using System.Threading.Tasks;
using DapperPerfTest.Common;
using DapperPerfTest.EFCore5.Scaffold;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DapperPerfTest.EFCore5
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
                .AddDbContext<NorthwindContext>(o => o.UseSqlServer("Name=ConnectionStrings:Sql")));
        }
    }
}