﻿using JT7SKU.Lib.Twitch;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Concurrency;
using Services.Kirjasto.Unit.Twitch.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Kirjasto.Unit.Twitch.Grains
{
    [Reentrant]
    public class TwitchAccount : Grain<TwitchAccountState>, ITwitchAccount
    {
        
        private const int ReceivedMessageCacheSize = 100;
        private const int PublishedMessageCacheSize = 100;
        private readonly ILogger<TwitchAccount> logger;
        private const int MAX_MESSAGE_LENGHT = 280;
        private Task outstandingWriteStateOperation;
        private readonly HashSet<ITwitchViewer> viewers = new HashSet<ITwitchViewer>();
        public TwitchAccount(ILogger<TwitchAccount> logger) => this.logger = logger;

        private string GrainType => nameof(TwitchAccount);
        private string GrainKey => this.GetPrimaryKeyString();
        #region Grain overrides
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            if (this.State.RecentReceiveMessages == null) this.State.RecentReceiveMessages = new Queue<Message>(ReceivedMessageCacheSize);
            if (this.State.MyPublishedMessages == null) this.State.MyPublishedMessages = new Queue<Message>(PublishedMessageCacheSize);
            if (this.State.Followers == null) this.State.Followers = new Dictionary<string, ITwitchFollower>();
            if (this.State.Subscriptions == null) this.State.Subscriptions = new Dictionary<string, ITwitchSubscriber>();
             //  if (this.State.Broadcaster == null) this.State.Broadcaster = new BroadcasterGrain();
            this.logger.LogInformation($"{this.GrainType}{this.GrainKey} activated.");
            await Task.CompletedTask;
        }
        #endregion
        #region ITwitchAccountGrain interface methods
        public async Task FollowUserIdAsync(string username)
        {
            this.logger.LogInformation($"{this.GrainType}{this.GrainKey} > FollowUserName({username})");
            var userToFollow = this.GrainFactory.GetGrain<ITwitchBroadcaster>(username);
            await userToFollow.AddFollowerAsync(this.GrainKey, this.AsReference<ITwitchFollower>());
           /// this.State.Followers[username] = userToFollow;
            await this.WriteStateAsync();
            this.viewers.ForEach(_ => _.FollowerAdded(username));            
        }
        public async Task PublishMessageAsync(string message)
        {
            var Glitch = this.CreateNewTwitchMessage(message);
            this.logger.LogInformation($"{GrainType} {GrainKey} publishing new glitch message {Glitch}");
            this.State.MyPublishedMessages.Enqueue(Glitch);
            while (this.State.MyPublishedMessages.Count > PublishedMessageCacheSize)
            {
                this.State.MyPublishedMessages.Dequeue();
            }
            await this.WriteStateAsync();
            this.logger.LogInformation($"{GrainType} {GrainKey} sending glitch message to {this.viewers.Count}");
            
        }
        public void NewBroadcast(Message message)
        {
            throw new NotImplementedException();
        }

        public async Task UnFollowUserIdAsync(string username)
        {
            this.logger.LogInformation($"{this.GrainType}{this.GrainKey} > UnFollowUserName({username})");
            await GrainFactory.GetGrain<ITwitchBroadcaster>(username).RemoveFollowerAsync(this.GrainKey);
            this.State.Followers.Remove(username);
            await this.WriteStateAsync();
            this.viewers.ForEach(_ =>_.FollowerRemoved(username));
        }

        public async Task AddFollowerAsync(string username, ITwitchFollower follower)
        {
            this.State.Followers[username] = follower;
            await this.WriteStateAsync();
        }

        public async Task RemoveFollowerAsync(string username)
        {
            this.State.Followers.Remove(username);
            await this.WriteStateAsync();
        }

        public async Task AddSubscriberAsync(string username, ITwitchSubscriber subscriber)
        {
            this.State.Subscriptions[username]=subscriber;
            await this.WriteStateAsync();
        }

        public async Task RemoveSubscriberAsync(string username)
        {
            this.State.Subscriptions.Remove(username);
            await this.WriteStateAsync();
        }

        public async Task<ImmutableList<Message>> GetReceivedWhispersAsync(int n = 10, int start = 0) 
        {
             throw new NotImplementedException();
        }

        

        public Task<ImmutableList<string>> GetFollowersListAsync() => Task.FromResult(this.State.Followers.Keys.ToImmutableList());

        public Task<ImmutableList<string>> GetSubscribersListAsync() => Task.FromResult(this.State.Subscriptions.Keys.ToImmutableList());

        public Task<ImmutableList<string>> GetBitsCheeredListAsync() => Task.FromResult(this.State.Cheers.Keys.ToImmutableList());

        public Task<ImmutableList<string>> GetTipsListAsync() => Task.FromResult(this.State.Tips.Keys.ToImmutableList());

        public Task NewSubscriber(User user,Message message)
        {
            throw new NotImplementedException();
        }

        public Task NewFollower(User user,Message message)
        {
            throw new NotImplementedException();
        }
        #endregion
        private Message CreateNewTwitchMessage(string message) => new Message {Context = message, UserId= this.GrainKey, Timestamp= DateTime.Now };
        protected override async Task WriteStateAsync()
        {
            var currentWriteStateOperation = this.outstandingWriteStateOperation;
            if(currentWriteStateOperation != null)
            {
                try
                {
                    await currentWriteStateOperation;
                }
                catch (Exception)
                {

                } 
                finally
                {
                    if(this.outstandingWriteStateOperation == currentWriteStateOperation)
                    {
                        this.outstandingWriteStateOperation = null;
                    }
                }
            }
            if (this.outstandingWriteStateOperation == null)
            {
                currentWriteStateOperation = base.WriteStateAsync();
                this.outstandingWriteStateOperation = currentWriteStateOperation;
            }
            else
            {
                currentWriteStateOperation = this.outstandingWriteStateOperation;
            }
            try
            {
                await currentWriteStateOperation;
            }            
            finally
            {
                if(this.outstandingWriteStateOperation == currentWriteStateOperation)
                {
                    this.outstandingWriteStateOperation = null;
                }
            }
        }

        public Task<ImmutableList<Message>> GetPublishedMessagesAsync(int n = 10, int start = 0)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFollowerAsync(string username, ITwitchFollower follower)
        {
            throw new NotImplementedException();
        }
    }
    public class TwitchAccountState
    {
       // public ITwitchBroadcaster Broadcaster { get; set; }
        public Dictionary<string, ITwitchSubscriber> Subscriptions { get; set; }
        public Dictionary<string, ITwitchFollower> Followers { get; set; }
        public Dictionary<string, ITwitchCheer> Cheers { get; set; }
        public Dictionary<string, ITwitchTip> Tips { get; set; }

        public Queue<Message> RecentReceiveMessages { get; set; }
        public Queue<Message> MyPublishedMessages { get; set; }
    }
}
