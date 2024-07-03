﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orleans;

namespace Services.Kontrakti.Unit.Twitch.Tili
{
    public interface ITwitchSubscriber :IGrainWithStringKey
    {
        Task NewSubscriber(IUser user,string message);
    }
}
