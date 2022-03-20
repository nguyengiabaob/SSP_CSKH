using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSKH_SSP.Interfaces;
using CSKH_SSP.DataModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using CSKH_SSP.Interfaces.ICountRequest;
using CSKH_SSP.Interfaces.ICheckPermission;
using CSKH_SSP.ViewModels.ListRequest;
using CSKH_SSP.Interfaces.IHelpersServices;

namespace CSKH_SSP.Controllers.RequestList
{
    [Authorize]
    public class RequestListController : Controller
    {
        private readonly IRequestListServices _requestListServices;
        private readonly ICountRequestServices _countRequestServices;
        private readonly ICheckGroupUserPermissionServices _checkGroupUserPermissionServices;
        private readonly IHelpersServices _helpersServices;
        public RequestListController(IRequestListServices requestListServices,
                                     ICountRequestServices countRequestServices,
                                     ICheckGroupUserPermissionServices checkGroupUserPermissionServices, IHelpersServices helpersServices)
        {
            _requestListServices = requestListServices;
            _countRequestServices = countRequestServices;
            _checkGroupUserPermissionServices = checkGroupUserPermissionServices;
            _helpersServices = helpersServices;
        }
        public IActionResult Index(int? mention, string statusRequest, int? pageNumber, string text, string category, string pri, string notification, string createBy, bool isGetData = false)
        {
            if (isGetData)
            {
                var page = pageNumber.HasValue ? pageNumber.Value : 18;
                if (text == "undefined")
                    text = "";
                if (statusRequest == "undefined")
                    statusRequest = "";
                if (category == "undefined")
                    category = "";
                if (pri == "undefined")
                    pri = "";
                if (notification == "undefined")
                    notification = "";
                if (createBy == "undefined")
                    createBy = "";
                ViewData["Notification"] = string.Empty;
                ViewData["CurrentStatusRequest"] = statusRequest;
                ViewData["text"] = text;
                ViewData["category"] = category = string.IsNullOrEmpty(category) ? null : category;
                ViewData["pri"] = pri = string.IsNullOrEmpty(pri) ? null : pri;
                ViewData["pageNumber"] = page;
                ViewData["TotalRequest"] = "";
                ViewData["TotalRequestView"] = "";

                //var Size = pageSize.HasValue
                //var getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
                CSKH_SSP.DataModels.User getCurrentUser;
                if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
                {
                    getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
                }
                else
                {
                    getCurrentUser = _helpersServices.getUserForTest();
                }
                //ViewBag.Username = getCurrentUser.UserName;

                var GroupUserID = getCurrentUser.GroupUserID;
                var UserName = getCurrentUser.UserName;
                //ViewBag.Username = getCurrentUser.UserName;
                var ListRequest = _requestListServices.GetListRequest(GroupUserID, UserName, mention, statusRequest, page, text, category, pri);
                var GroupUserPermission = _checkGroupUserPermissionServices.GetGroupUserPermission(GroupUserID);
                ListRequestAndPermission listRequestAndPermission = new ListRequestAndPermission();

                if (string.IsNullOrEmpty(statusRequest))
                {
                    ViewData["CurrentStatus"] = "Open";
                }
                else
                {
                    ViewData["CurrentStatus"] = statusRequest;
                }
                listRequestAndPermission.GroupUserPermission = GroupUserPermission;
                listRequestAndPermission.ListRequest = ListRequest.ListRequestTickets;
                //listRequestAndPermission.MinPage = ListRequest.MinPage;
                //listRequestAndPermission.MaxPage = ListRequest.MaxPage;
                //listRequestAndPermission.TotalItem = ListRequest.TotalRequest; // So trang :)))))
                listRequestAndPermission.TotalItem = ListRequest.TotalRequest;
                listRequestAndPermission.IsLastItem = ListRequest.isLastItem;
                if (!string.IsNullOrEmpty(notification))
                    ViewData["Notification"] = "NewRequest";
                return View(listRequestAndPermission);
            } else
            {
                //activeStatus
                return RedirectToAction("Index", "Home", new { activeStatus = statusRequest });
            }

        }
        public JsonResult CountRequestStatus()
        {
            // var getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User getCurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                getCurrentUser = _helpersServices.getUserForTest();
            }

            var GroupUserID = getCurrentUser.GroupUserID;
            var UserName = getCurrentUser.UserName;
            var obj = _countRequestServices.CountNotification(GroupUserID, UserName);
            return new JsonResult(obj);
        }
        public string MyNotification(string Username)
        {
            var count = _countRequestServices.CountNotificationOfUser(Username);
            return count;
        }
    }
}