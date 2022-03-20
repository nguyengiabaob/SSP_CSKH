using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.Notifications
{
    public class NotificationView
    {
        public int IdNotification { get; set; }
        public string RequestID { get; set; }
        public string type_noti { get; set; }
        public string RequestName { get; set; }
        public int ToUserID { get; set; }
        public string ToUser { get; set; }
        public int FromUserID { get; set; }
        public string FromUser { get; set; }
        public bool isSeen { get; set; }
        public bool isRead { get; set; }
        public DateTime Time { get; set; }
    }
}
