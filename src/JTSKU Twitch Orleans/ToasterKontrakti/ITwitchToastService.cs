using Orleans.Services;
using Services.Kontrakti.Unit.Twitch.Tili;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Kontrakti.Unit.Twitch.Toaster
{
   public  interface ITwitchToastService : IGrainService
    {
        Task NewToast(IUser user,ToastLevel toastLevel, string message);
        void ShowToast(string message, ToastLevel level);
        
    }
}
