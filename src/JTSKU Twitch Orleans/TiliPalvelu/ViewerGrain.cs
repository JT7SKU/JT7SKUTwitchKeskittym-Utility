using System;
using System.Collections.Generic;
using System.Text;
using Orleans;
using System.Threading.Tasks;
using System.Threading;
using Services.Kontrakti.Unit.Twitch.Tili;

namespace Services.Kirjasto.Unit.Twitch.Tili
{
    public class ViewerGrain : Grain,ITwitchViewer
    {
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        public void FollowerAdded(string username)
        {
            throw new NotImplementedException();
        }

        public void FollowerRemoved(string username)
        {
            throw new NotImplementedException();
        }

        public void NewViewer(string message)
        {
            throw new NotImplementedException();
        }

        public void SubscriptionAdded(string username)
        {
            throw new NotImplementedException();
        }

        public void SubscriptionRemoved(string username)
        {
            throw new NotImplementedException();
        }
    }
}
