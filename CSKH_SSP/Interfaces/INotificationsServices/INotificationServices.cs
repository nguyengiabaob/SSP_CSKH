using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.INotificationsServices
{
    public interface INotificationServices
    {
        public void SetNotification(string ReqID, string type_id, string toUserName, string OwnerUserName, DateTime Time);
        public void SetNotificationForDepartment(string ReqID, string type_id, int DepartmentID, string OwnerUserName, DateTime Time);
        public int CountNotificationByUserID(User user);
        public int SetNotificationIsSeen(User user);
        public string SetNotificationIsRead(int NotificationID, User user);
        public List<NotificationView> getAllNotification(User user);
        public string SetOnChangeIsRead(string RequestID, User user);
        public bool isRequestHasOnchange(string RequestID, string UserName);
    }
}
