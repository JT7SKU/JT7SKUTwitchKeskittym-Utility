using Orleans;
using Services.Kontrakti.Unit.Twitch.Tili;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Kirjasto.Unit.Twitch.Tili
{
    public class SubscriberGrain : Grain, ITwitchSubscriber
    {
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        public Task NewSubscriber(IUser user,string message)
        {
            throw new NotImplementedException();
        }
    }
}
