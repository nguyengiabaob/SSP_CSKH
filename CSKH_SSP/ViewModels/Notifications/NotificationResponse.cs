using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.Notifications
{
    public class NotificationResponse
    {
        public string Content { get; set; }
        public string RequestID { get; set; }
        public DateTime Time { get; set; }
        public bool IsRead { get; set; }
        public int NotificationID { get; set; }
    }
}
