﻿
using Orleans;

using Services.Kontrakti.Unit.Twitch.Tip;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Kirjasto.Unit.Twitch.Tip
{
    public class TipperGrain :Grain, ITwitchTip
    {
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        
                   
        public Task NewTip(int arvo, string message)
        {
            throw new NotImplementedException();
        }
    }
}
