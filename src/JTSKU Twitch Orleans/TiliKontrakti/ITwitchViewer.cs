using System;
using System.Collections.Generic;
using System.Text;
using Orleans;

namespace Services.Kontrakti.Unit.Twitch.Tili
{
    public interface ITwitchViewer : IGrainObserver
    {
        void NewViewer(string message);
        void SubscriptionAdded(string username);
        void SubscriptionRemoved(string username);
        void FollowerAdded(string username);
        void FollowerRemoved(string username);
    }
}
