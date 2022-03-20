using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.INotificationsServices;
using CSKH_SSP.ViewModels.Notifications;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Services.NotificationsServices
{
    public class NotificationServices : INotificationServices
    {
        private readonly DataContext _dataContext;

        public NotificationServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SetNotification(string ReqID, string type_id, string UserName, string OwnerUserName, DateTime Time)
        {
            Notification notification = new Notification();
            notification.requestID = ReqID;
            notification.type_id = type_id;
            notification.UserName = UserName;
            notification.OwnerUserName = OwnerUserName;
            notification.isRead = false;
            notification.isSeen = false;
            notification.Time = Time;
            _dataContext.Notification.Add(notification);
            //_dataContext.SaveChanges();
        }
        public void SetNotificationForDepartment(string ReqID, string type_id, int DepartmentID, string OwnerUserName, DateTime Time)
        {
            var userInDepartment = _dataContext.User.Where(x => x.DepartmentID == DepartmentID);

            foreach (var item in userInDepartment.ToList())
            {
                Notification notification = new Notification();
                notification.requestID = ReqID;
                notification.type_id = type_id;
                notification.DepartmentID = DepartmentID;
                notification.UserName = item.UserName;
                notification.OwnerUserName = OwnerUserName;
                notification.isRead = false;
                notification.isSeen = false;
                notification.Time = Time;
                _dataContext.Notification.Add(notification);
                //_dataContext.SaveChanges();
                //_dataContext.SaveChanges();
            }
            //_dataContext.SaveChanges();

        }

        public int CountNotificationByUserID(User user)
        {
            return _dataContext.Notification.Where(x => x.UserName == user.UserName && x.isSeen == false).Count();
        }
        public int SetNotificationIsSeen(User user)
        {
            var temNotification = _dataContext.Notification.Where(x => x.UserName == user.UserName).ToList();
            foreach (var i in temNotification)
            {
                i.isSeen = true;
                _dataContext.SaveChanges();
            }
            return 1;
        }
        public string SetNotificationIsRead(int NotificationID, User user)
        {
            var a = _dataContext.Notification.Where(x => x.notification_id == NotificationID && x.UserName == user.UserName).FirstOrDefault();
            if (a.UserName == user.UserName)
            {
                a.isRead = true;
                _dataContext.SaveChanges();
            }
            return a.requestID;
        }
        public string SetOnChangeIsRead(string RequestID, User user)
        {
           
                var a = _dataContext.Notification.Where(x => x.requestID == RequestID && x.UserName == user.UserName);
                foreach (var item in a)
                {

                    //Notification qa = _dataContext.Notification.Where(x => x.notification_id == item.notification_id).FirstOrDefault();
                    _dataContext.Notification.Remove(item);
                }
                _dataContext.SaveChanges();
                return "Ok";
           
            
        }

        public bool isRequestHasOnchange(string RequestID, string UserName)
        {
            try {
                //var obj1 = _dataContext.Notification.Where(x => x.requestID == RequestID && x.UserName == UserName).Select(x=>x.OwnerUserName).ToList();
                var obj = _dataContext.Notification.Where(x => x.requestID == RequestID && x.UserName == UserName).FirstOrDefault();

                if (obj != null)
                    return true;
                return false;
            } catch (Exception e)
            {
                var aa = e;
                return false;
            }
            
        }
        public List<NotificationView> getAllNotification(User user)
        {
            var temp = (from a in _dataContext.Notification
                        join c in _dataContext.User on a.UserName equals c.UserName
                        join b in _dataContext.Request on a.requestID equals b.RequestID
                        join d in _dataContext.User on a.OwnerUserName equals d.UserName
                        where a.UserName == user.UserName
                        select new NotificationView()
                        {
                            IdNotification = a.notification_id,
                            RequestID = a.requestID,
                            RequestName = b.RequestTittle,
                            type_noti = a.type_id,
                            ToUserID = c.UserID,
                            ToUser = c.FullName,
                            FromUserID = d.UserID,
                            FromUser = d.FullName,
                            Time = a.Time,
                            isSeen = a.isSeen,
                            isRead = a.isRead
                        }).OrderByDescending(x => x.IdNotification).ToList();
            return temp;
        }


    }
}
