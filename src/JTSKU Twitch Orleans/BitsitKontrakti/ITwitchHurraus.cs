using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Kontrakti.Unit.Twitch.Hurraus
{
    public interface ITwitchHurraus
    {
        Task NewCheer(int arvo,string message);
    }
}
