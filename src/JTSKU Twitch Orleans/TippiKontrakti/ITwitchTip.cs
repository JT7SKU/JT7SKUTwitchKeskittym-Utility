using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Kontrakti.Unit.Twitch.Tip
{
    public interface ITwitchTip
    {
        Task NewTip(int arvo,string message);
    }
}
