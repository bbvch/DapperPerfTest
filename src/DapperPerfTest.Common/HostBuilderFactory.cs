using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DapperPerfTest.Common
{
    public static class HostBuilderFactory
    {
        public static IHostBuilder Create(string[] args)
        {
            return new HostBuilder()
                .ConfigureHostConfiguration(_ => _.AddInMemoryCollection(new Dictionary<string, string>
                {
                    { HostDefaults.ContentRootKey, Directory.GetCurrentDirectory() }
                }))
                .ConfigureAppConfiguration(_ => _
                    .AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "ConnectionStrings:Sql", Config.Connection }
                    })
                    .AddEnvironmentVariables()
                    .AddCommandLine(args))
                .ConfigureLogging(_ =>
                {
                    _.SetMinimumLevel(LogLevel.Warning);
                    _.AddSimpleConsole();
                })
                .UseDefaultServiceProvider(_ =>
                {
                    _.ValidateOnBuild = true;
                    _.ValidateScopes = true;
                });
        }
    }
}
