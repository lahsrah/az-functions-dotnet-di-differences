using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using DotNet8_InProcess;

[assembly: FunctionsStartup(typeof(Startup))]
namespace DotNet8_InProcess
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<IService, Service>();
        }
    }
}
