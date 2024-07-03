using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Services.Kontrakti.Unit.Twitch.Tili;

namespace Services.Kontrakti.Unit.Twitch.Seuranta
{
    public interface ITwitchFollow : IGrainWithStringKey
    {
        Task NewFollower(IUser user, string message);
    }
}
