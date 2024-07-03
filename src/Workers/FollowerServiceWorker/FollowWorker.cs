using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.BroadcastChannel;
using Orleans.Concurrency;
using Orleans.Hosting;
using Services.Kirjasto.Unit.Twitch.Interfaces;

namespace FollowerServiceWorker
{
    [StatelessWorker]
    public class FollowWorker :  BackgroundService, IFollowWorkerGrain
    {
        private readonly ILogger<FollowWorker> _logger;
        private readonly IBroadcastChannelProvider _provider;
        public FollowWorker(ILogger<FollowWorker> logger, IClusterClient clusterClient)
        {
            _logger = logger;
            //_provider = clusterClient.GetBroadcastChannelProvider(ChannelNames.FollowWorker);
        }

        public Task AddFollow(ITwitchFollow twitchFollow)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFollow(ITwitchFollow twitchFollower)
        {
            throw new NotImplementedException();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                long startingTimestamp = Stopwatch.GetTimestamp();
                _logger.LogInformation("FollowWorker running at: {time}", DateTimeOffset.UtcNow);


                int elapsed = Stopwatch.GetElapsedTime(startingTimestamp).Milliseconds;
                int remaining = Math.Max(0, 15000 - elapsed);
                await Task.Delay(remaining, stoppingToken);
            }
        }
    }
}
