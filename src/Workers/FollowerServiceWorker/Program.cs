using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;
using Orleans.Hosting;

namespace FollowerServiceWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)            
            .UseWindowsService()
            .UseOrleans(builder => builder.UseLocalhostClustering())
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<FollowWorker>();
                    services.AddOpenTelemetry().UseOtlpExporter();
                });
    }
}
