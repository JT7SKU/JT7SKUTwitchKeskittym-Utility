using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Orleans.Configuration;

namespace JT7SKU_TwitchR.Infra
{
    public static class OrleansApplicationBuilderExtensions
    {
        public static HostBuilder AsOrleansSilo(this HostBuilder builder, Action<ISiloBuilder>? siloBuilderKallBack = null)
        {
            builder.UseOrleans(silo =>
            {
                silo.Configure<ClusterMembershipOptions>(o =>
                {
                    o.IAmAliveTablePublishTimeout = TimeSpan.FromSeconds(30);
                    o.NumMissedTableIAmAliveLimit = 4;
                });
                if(siloBuilderKallBack != null)
                {
                    siloBuilderKallBack(silo);
                }
            });
            return builder;
        }
        public static HostBuilder AsOrleansAsiaskas(this HostBuilder builder)
        {
            builder.UseOrleansClient(asiakas =>
            {
                asiakas.Configure<GatewayOptions>(o =>
                {
                    o.GatewayListRefreshPeriod = TimeSpan.FromSeconds(30);
                });
            });
            return builder;
        }
    }
}
