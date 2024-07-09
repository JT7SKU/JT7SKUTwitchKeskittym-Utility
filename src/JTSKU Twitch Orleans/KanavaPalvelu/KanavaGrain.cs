using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Providers;
using Services.Kontrakti.Unit.Twitch.Kanava;
using Services.Kontrakti.Unit.Twitch.Seuranta;
using Services.Kontrakti.Unit.Twitch.Tili;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Kirjasto.Unit.Twitch.Kanva
{
    [StorageProvider(ProviderName="Kanava")]
    public class KanavaGrain : Grain<KanavaState> , ITwitchKanava
    {
        private Kanava Kanava;
        private readonly ILogger<KanavaGrain> logger;
        private readonly HashSet<ITwitchViewer> viewers = new HashSet<ITwitchViewer>();
        private string GrainType => nameof(KanavaGrain);
        private string GrainKey => this.GetPrimaryKeyString();
        public KanavaGrain(ILogger<KanavaGrain> logger)
        {
            this.logger = logger;
        }
        
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            this.State.IsLive = true;
            this.State.Subscriptions = new Dictionary<string, ITwitchSubscriber>();
            this.State.Followers = new Dictionary<string, ITwitchFollow>();
            await Task.CompletedTask;
        }

        #region Viewer portion

        public Task SubscribeAsync(ITwitchViewer viewer)
        {
            this.viewers.Add(viewer);
            return Task.CompletedTask;
        }

        public Task UnSubscribeAsync(ITwitchViewer viewer)
        {
            this.viewers.Remove(viewer);
            return Task.CompletedTask;
        }

        public Task FollowAsync(ITwitchViewer viewer)
        {
            this.viewers.Add(viewer);
            return Task.CompletedTask;
        }

        public Task UnFollowAsync(ITwitchViewer viewer)
        {
            this.viewers.Remove(viewer);
            return Task.CompletedTask;
        }
        #endregion 
    }
    public class KanavaState
    {
        public bool IsLive { get; set; }

        public Dictionary<string, ITwitchSubscriber> Subscriptions { get; set; }
        public Dictionary<string, ITwitchFollow> Followers { get; set; }
    }
}
