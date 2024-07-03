using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Kontrakti.Unit.Twitch.Bitsit
{
    public interface ITwitchCheer
    {
        Task NewCheer(int arvo,string message);
    }
}
