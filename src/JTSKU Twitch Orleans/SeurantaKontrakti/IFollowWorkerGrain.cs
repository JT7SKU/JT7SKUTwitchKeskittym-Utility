using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Kirjasto.Unit.Twitch.Interfaces
{
    public interface IFollowWorkerGrain
    {
        Task AddFollow(ITwitchFollow twitchFollower);
        Task RemoveFollow(ITwitchFollow twitchFollower);
    }
}
