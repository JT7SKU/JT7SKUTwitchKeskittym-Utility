using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Orleans.Configuration;

namespace Microsoft.AspNetCore.Builder
{
    public static class OrleansWebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AsOrleansSilo(this WebApplicationBuilder builder, Action<ISiloBuilder>? siloBuilderKallBack = null)
        {
            
            builder.UseOrleans(silo =>
            {
                silo.UseRedisClustering(opt =>
                {
                    
                    //opt.ConfigurationOptions. = "host:port";
                    opt.ConfigurationOptions.DefaultDatabase = 0;
                });
                silo.AddRedisGrainStorageAsDefault();
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
        public static WebApplicationBuilder AsOrleansAsiaskas(this WebApplicationBuilder builder)
        {
            builder.UseOrleansClient(asiakas =>
            {
                asiakas.UseRedisClustering(opt => {
                    //opt.ConnectionString = "host:port";
                    opt.ConfigurationOptions.DefaultDatabase = 0;
                });
                asiakas.Configure<GatewayOptions>(o =>
                {
                    o.GatewayListRefreshPeriod = TimeSpan.FromSeconds(30);
                });
            });
            return builder;
        }
    }
}
