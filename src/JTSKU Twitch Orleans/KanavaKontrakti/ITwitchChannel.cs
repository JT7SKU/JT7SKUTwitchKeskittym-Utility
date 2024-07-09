using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Services.Kontrakti.Unit.Twitch.Tili;
namespace Services.Kontrakti.Unit.Twitch.Kanava
{
    public interface ITwitchKanava : IGrainWithIntegerKey
    {
        Task SubscribeAsync(ITwitchViewer viewer);
        Task UnSubscribeAsync(ITwitchViewer viewer);
        Task FollowAsync(ITwitchViewer viewer);
        Task UnFollowAsync(ITwitchViewer viewer);
    }
}
