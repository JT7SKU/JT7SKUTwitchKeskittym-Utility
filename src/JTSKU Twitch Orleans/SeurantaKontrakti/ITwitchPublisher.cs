
using Orleans;
using Services.Kontrakti.Unit.Twitch.Seuranta;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading.Tasks;

namespace Services.Kontrakti.Unit.Twitch.Seuranta
{
    public interface ITwitchPublisher: IGrainWithStringKey
    {
        Task<ImmutableList<string>> GetPublishedMessagesAsync(int n = 10, int start = 0);
        Task AddFollowerAsync(string username, ITwitchFollow follower);
        Task RemoveFollowerAsync(string username, ITwitchFollow follower);
    }
}
