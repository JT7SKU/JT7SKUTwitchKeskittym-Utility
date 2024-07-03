using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Orleans;
using Services.Kontrakti.Unit.Twitch.Seuranta;
using Services.Kontrakti.Unit.Twitch.Tili;

namespace Services.Kirjasto.Unit.Twitch.Seuranta
{
    public class FollowerGrain : Grain, ITwitchFollow
    {
        private readonly Follower follower;
        private bool IsFollowing = false;
        
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        public Task NewFollower(IUser user,string message)
        {
            follower.User = user;
            IsFollowing = true;
            return Task.CompletedTask;
        }
    }
}
