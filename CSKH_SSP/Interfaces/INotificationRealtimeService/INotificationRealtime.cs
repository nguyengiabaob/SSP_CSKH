using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.INotificationRealtimeService
{
   public interface INotificationRealtime
    {
        public int CountNotification(string UserName);
    }
}
