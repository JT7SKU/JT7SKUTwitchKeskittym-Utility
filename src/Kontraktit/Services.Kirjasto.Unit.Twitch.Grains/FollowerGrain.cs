﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JT7SKU.Lib.Twitch;
using Orleans;
using Services.Kirjasto.Unit.Twitch.Interfaces;

namespace Services.Kirjasto.Unit.Twitch.Grains
{
    public class FollowerGrain : Grain, ITwitchFollower
    {
        private readonly Follower follower;
        private bool IsFollowing = false;
        
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        public Task NewFollower(User user,Message message)
        {
            follower.User = user;
            IsFollowing = true;
            return Task.CompletedTask;
        }
    }
}
