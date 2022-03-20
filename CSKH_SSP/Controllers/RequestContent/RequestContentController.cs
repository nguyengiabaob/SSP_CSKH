using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces;
using CSKH_SSP.Interfaces.ICheckPermission;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Interfaces.IIncidentRequestServices;
using CSKH_SSP.Interfaces.INotificationsServices;
using CSKH_SSP.ViewModels.ContentRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace CSKH_SSP.Controllers.RequestContent {
    [Authorize]
    public class RequestContentController : Controller {
        private readonly IRequestContentHeaderServices _requestContentHeaderServices;
        private readonly IRequestContentBodyServices _requestContentBodyServices;
        private readonly ICheckGroupUserPermissionServices _checkGroupUserPermissionServices;
        private readonly ICheckRequestPermissionServices _checkRequestPermissionServices;
        private readonly INotificationServices _notificationServices;
        private readonly IHelpersServices _helpersServices;
        private readonly IIncidentRequestServices _incidentRequestServices;

        public RequestContentController (IRequestContentHeaderServices requestContentHeaderServices,
            IRequestContentBodyServices requestContentBodyServices,
            ICheckGroupUserPermissionServices checkGroupUserPermissionServices,
            ICheckRequestPermissionServices checkRequestPermissionServices,
            INotificationServices notificationServices, IHelpersServices helpersServices, IIncidentRequestServices incidentRequestServices) {
            _requestContentHeaderServices = requestContentHeaderServices;
            _requestContentBodyServices = requestContentBodyServices;
            _checkGroupUserPermissionServices = checkGroupUserPermissionServices;
            _checkRequestPermissionServices = checkRequestPermissionServices;
            _notificationServices = notificationServices;
            _helpersServices = helpersServices;
            _incidentRequestServices = incidentRequestServices;
        }
        public List<Reason> GetReason () {
            return _helpersServices.getListReason ();
        }

        public IActionResult RequestContent (string RequestID, bool isGetDataOnly = false) {
            if (!isGetDataOnly)
            {
                return RedirectToAction("Index", "Home", new { RequestID = RequestID});
            }
            if (string.IsNullOrEmpty (RequestID)) {
                return null;
            }
            ViewData["RequestID"] = string.Empty;
            if (!string.IsNullOrEmpty (RequestID)) {
                ViewData["RequestID"] = RequestID;
                HttpContext.Session.SetString ("SessionRequestID", JsonConvert.SerializeObject (RequestID));
            }

            //var CurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User CurrentUser;
            if (!string.IsNullOrEmpty (HttpContext.Session.GetString ("SessionCurrentUser") as string)) {
                CurrentUser = JsonConvert.DeserializeObject<User> (HttpContext.Session.GetString ("SessionCurrentUser"));
            } else {
                CurrentUser = _helpersServices.getUserForTest ();
            }
            //ViewBag.Username = CurrentUser.UserName;




                var listUserCanView = _checkRequestPermissionServices.ListUserCanViewRequest(RequestID, CurrentUser.DepartmentID, CurrentUser.UserName);
                bool isCanView = listUserCanView.Any(x => x.UserName == CurrentUser.UserName);
                bool isAdmin = _checkGroupUserPermissionServices.IsAdmin(CurrentUser.GroupUserID);
                if (isCanView || isAdmin)
                {
                    var setisReadOnChange = _notificationServices.SetOnChangeIsRead(RequestID, CurrentUser);
                    //var getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));

                    var GroupUserID = CurrentUser.GroupUserID;
                    var CurrentUserName = CurrentUser.UserName;
                    var CurrentDepartment = CurrentUser.DepartmentID;

                    var FullRequestModel = new ContentRequest();
                    var ListUsersAssign = _requestContentBodyServices.GetUserAssign(RequestID);
                    var RequestInfo = _requestContentHeaderServices.GetInfoRequest(RequestID, CurrentUser.UserName);
                    if (CurrentUser.UserName == RequestInfo.createByUserName)
                    {
                        RequestInfo.isCreateRequest = true;
                    }
                    else
                    {
                        RequestInfo.isCreateRequest = false;
                    }
                    if (ListUsersAssign.Any(x => x.UserName == CurrentUser.UserName))
                    {
                        RequestInfo.isAssignRequest = true;
                    }
                    else
                    {
                        RequestInfo.isAssignRequest = false;
                    }
                    RequestInfo.isAdmin = isAdmin;
                    var RequestContent = _requestContentBodyServices.GetRequestComment(RequestID);
                    var AttFile = _requestContentBodyServices.GetAttachFiles(RequestID);
                    var ListPrivateChat = _requestContentBodyServices.GetPrivateChat(RequestID);
                    var UserInfomation = _requestContentBodyServices.GetUserInfomation(RequestID);
                    var ListDepartmentsAssign = _requestContentBodyServices.GetDepartmentAssign(RequestID);
                    var ListDepartmentsFollow = _requestContentBodyServices.GetDepartmentFollow(RequestID);

                    var ListUsersFollow = _requestContentBodyServices.GetUserFollow(RequestID);
                    var GroupUserPermission = _checkGroupUserPermissionServices.GetGroupUserPermission(GroupUserID);
                    var RenderBtn = _requestContentHeaderServices.RenderButton(RequestID, CurrentDepartment, CurrentUserName);
                    var TicketID = _requestContentBodyServices.GetTicketID(RequestID);
                    var TicketCustomerID = _requestContentBodyServices.GeTicketCustomerID(RequestID);
                    var ContractID = _requestContentBodyServices.GeTicketContractID(RequestID);

                    FullRequestModel.IsPinned = _helpersServices.checkReqeustIdPinned(RequestID, CurrentUser.UserName);

                    FullRequestModel.ContentRequestHeader = RequestInfo;
                    FullRequestModel.ContentRequestBody = RequestContent;
                    FullRequestModel.AttachFile = AttFile;
                    FullRequestModel.PrivateChat = ListPrivateChat;
                    FullRequestModel.UserCreateRequestInfomation = UserInfomation;
                    FullRequestModel.ListDepartmentsAssign = ListDepartmentsAssign.ToList();
                    FullRequestModel.ListDepartmentsFollow = ListDepartmentsFollow.ToList();
                    FullRequestModel.ListUsersAssign = ListUsersAssign.ToList();
                    FullRequestModel.ListUsersFollow = ListUsersFollow.ToList();
                    FullRequestModel.GroupUserPermission = GroupUserPermission;
                    FullRequestModel.RenderButton = RenderBtn;
                    FullRequestModel.TicketID = TicketID;
                    FullRequestModel.TicketCustomerID = TicketCustomerID;
                    FullRequestModel.ContractID = ContractID;
                    FullRequestModel.RequestIncident = _incidentRequestServices.GetRequestIncident(RequestID);



                    ViewBag.RequestID = RequestID;
                    //var a = FullRequestModel.ListDepartmentsAssign.Count();
                    return View(FullRequestModel);
                }
                else
                {
                    return RedirectToAction("Index", new RouteValueDictionary(
                        new { controller = "Error", action = "Index", TextNote = "404" }));
                }

        }
    }
}