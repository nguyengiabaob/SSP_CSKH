using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Constant;
using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Interfaces.INotificationRealtimeService;
using CSKH_SSP.Interfaces.INotificationsServices;
using CSKH_SSP.ViewModels.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CSKH_SSP.Controllers.Notifications
{
    public class NotificationsController : Controller
    {
        private readonly INotificationServices _notificationServices;
        private readonly IHelpersServices _helpersServices;
        private readonly INotificationRealtime _notificationRealtime;

        public NotificationsController(INotificationServices notificationServices, IHelpersServices helpersServices, INotificationRealtime notificationRealtime)
        {
            _notificationServices = notificationServices;
            _helpersServices = helpersServices;
            _notificationRealtime = notificationRealtime;
        }

        public IActionResult Index()
        {
            return View();
        }
        public int CountNotification()
        {
            //var CurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User getCurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                getCurrentUser = _helpersServices.getUserForTest();
            }

            return _notificationServices.CountNotificationByUserID(getCurrentUser);
        }

        public int ListenNotificationOnRealTime()
        {
            CSKH_SSP.DataModels.User getCurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                getCurrentUser = _helpersServices.getUserForTest();
            }
            return _notificationRealtime.CountNotification(getCurrentUser.UserName);
        }

        public void SeenAllNotification()
        {
            //var CurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User getCurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                getCurrentUser = _helpersServices.getUserForTest();
            }

            var a = _notificationServices.SetNotificationIsSeen(getCurrentUser);
        }
        public IActionResult setNotificationIsRead(int NotificationID)
        {
            //var CurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User getCurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                getCurrentUser = _helpersServices.getUserForTest();
            }

            var RequestID = _notificationServices.SetNotificationIsRead(NotificationID, getCurrentUser);
            return RedirectToAction("RequestContent", "RequestContent", new { RequestID = RequestID });
        }
        public JsonResult GetNotification()
        {
            //var CurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User getCurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                getCurrentUser = _helpersServices.getUserForTest();
            }

            var obj = _notificationServices.getAllNotification(getCurrentUser);
            List<NotificationResponse> listResponse = new List<NotificationResponse>();
            if(obj.Count > 0)
            {
                foreach (var item in obj)
                {
                    var Response = new NotificationResponse();
                    if (item.type_noti == StringLibrary.Notification_AddUserAssign)
                    {
                        Response.Content = item.FromUser + " đã thêm bạn hỗ trợ yêu cầu " + item.RequestName;
                        Response.RequestID = item.RequestID;
                        Response.NotificationID = item.IdNotification;
                        Response.Time = item.Time;
                        Response.IsRead = item.isRead;
                        listResponse.Add(Response);
                    }
                    else if (item.type_noti == StringLibrary.Notification_RejectRequest)
                    {
                        Response.Content = item.FromUser + " đã từ chối hỗ trợ yêu cầu " + item.RequestName;
                        Response.RequestID = item.RequestID;
                        Response.NotificationID = item.IdNotification;
                        Response.Time = item.Time;
                        Response.IsRead = item.isRead;
                        listResponse.Add(Response);
                    }
                    else if (item.type_noti == StringLibrary.Notification_AddDepartmentAssign)
                    {
                        Response.Content = item.FromUser + " đã thêm phòng bạn vào hỗ trợ yêu cầu " + item.RequestName;
                        Response.RequestID = item.RequestID;
                        Response.NotificationID = item.IdNotification;
                        Response.Time = item.Time;
                        Response.IsRead = item.isRead;
                        listResponse.Add(Response);
                    }
                    else
                    //(item.type_noti == StringLibrary.Notification_AddNewComment)
                    {
                        Response.Content = item.FromUser + " đã gửi trả lời trong yêu cầu " + item.RequestName;
                        Response.RequestID = item.RequestID;
                        Response.Time = item.Time;
                        listResponse.Add(Response);
                    }
                }
            } else
            {
                var Response = new NotificationResponse();
                Response.Content ="Không có thông báo";
                //Response.RequestID = item.RequestID;
                //.Time = item.Time;
                listResponse.Add(Response);
            }
            
            return new JsonResult(listResponse);
        }

    }
}