using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans.Configuration;

namespace JT7SKU_TwitchR.Infra
{
    public static class OrleansApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AsOrleansSilo(this WebApplicationBuilder builder, Action<ISiloBuilder>? siloBuilderKallBack = null)
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
        }
        public static WebApplicationBuilder AsOrleansAsiaskas(this WebApplicationBuilder builder)
        {
            buildr.UseOrleansClient(asiakas =>
            {
                asiakas.Configure<GatewayOptions>(o =>
                {
                    o.GatewayListRefreshedPeriod = TimeSpan.FromSeconds(30);
                });
            });
            return builder;
        }
    }
}
