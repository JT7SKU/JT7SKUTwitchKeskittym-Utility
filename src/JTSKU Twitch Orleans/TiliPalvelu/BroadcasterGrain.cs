﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime;
using System.Threading;
using Services.Kontrakti.Unit.Twitch.Tili;
using Services.Kontrakti.Unit.Twitch.Seuranta;

namespace Services.Kirjasto.Unit.Twitch.Tili
{
    public class BroadcasterGrain :Grain, ITwitchBroadcaster
    {
        private readonly IPersistentState<ProfileState> _broadcasterProfile;

        public BroadcasterGrain([PersistentState("broadcaster","broadcasterstore")] IPersistentState<ProfileState> broadcasterState)
        {
            _broadcasterProfile = broadcasterState;
        }
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        public Task<IUser> GetBroadcasterAsync() => Task.FromResult(_broadcasterProfile.State.User);
        public async Task SetBroadcasterAsync(Broadcaster broadcaster)
        {
            _broadcasterProfile.State.User = broadcaster.User;
            _broadcasterProfile.State.UserStatus = UserStatus.Broadcaster;
            await _broadcasterProfile.WriteStateAsync();
        }
        public Task AddFollowerAsync(string username, IUser follower)
        {
            throw new NotImplementedException();
        }

        public async Task AddSubscriberAsync(string username, ITwitchSubscriber subscriber)
        {
            await Task.CompletedTask;
        }

        public Task<ImmutableList<string>> GetBitsCheeredListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableList<string>> GetFollowersListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableList<string>> GetSubscribersListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableList<string>> GetTipsListAsync()
        {
            throw new NotImplementedException();
        }


        public Task RemoveFollowerAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task RemoveSubscriberAsync(string username)
        {
            throw new NotImplementedException();
        }

        public void NewBroadcast(string message)
        {
            throw new NotImplementedException();
        }
    }
}
