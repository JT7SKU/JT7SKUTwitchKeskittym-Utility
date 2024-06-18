using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using System;
using Orleans.Hosting;
using Orleans;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;

namespace StreamKomponentsUnit.Twitch.Services
{
   public class Program
    {
         
        public static void Main(string[] args)
        {
            var builder = SiloHostBuilder(args);
            builder.ConfigureServices(services =>
            {
                services.AddOpenTelemetry().UseOtlpExporter();
            });

                builder.Build().Run();
        }
        public static IHostBuilder SiloHostBuilder (string[] args)
        {
            return SiloHostBuilder(args).UseOrleans((siloBuilder) =>
            {
                siloBuilder.UseLocalhostClustering()
                    .Configure<ClusterOptions>(options =>
                    {
                        options.ClusterId = "dev";
                        options.ServiceId = "TwitchDevApp";
                    })
                    .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback);
            });
        }
    }
}
