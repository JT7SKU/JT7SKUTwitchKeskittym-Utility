using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Orleans;
using Services.Kontrakti.Unit.Twitch.Bitsit;

namespace Services.Kirjasto.Unit.Twitch.Bitsit
{
    public class CheererGrain : Grain, ITwitchCheer
    {
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        public Task NewCheer(int arvo,string message)
        {
            throw new NotImplementedException();
        }
    }
}
