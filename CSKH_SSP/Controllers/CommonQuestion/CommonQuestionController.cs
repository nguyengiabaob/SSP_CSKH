using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces;
using CSKH_SSP.Interfaces.IAddNewRequestServices;
using CSKH_SSP.Interfaces.ICheckPermission;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Interfaces.IIncidentRequestServices;
using CSKH_SSP.Interfaces.INotificationsServices;
using CSKH_SSP.Interfaces.IQuestionsService;
using CSKH_SSP.Interfaces.ITicketServices;
using CSKH_SSP.ViewModels.AddNewQuestion;
using CSKH_SSP.ViewModels.AddNewRequest;
using CSKH_SSP.ViewModels.ContentRequest;
using CSKH_SSP.ViewModels.ListRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CSKH_SSP.Controllers
{
    [Authorize]
    public class CommonQuestionController : Controller
    {
        private readonly IHelpersServices _helpersServices;
        private readonly ITicketServices _ticketServices;
        private readonly ICommonQuestionService _QuestionService;
        private readonly ICheckGroupUserPermissionServices _checkGroupUserPermissionServices;
        private readonly IRequestContentBodyServices _RequestContentBodyServices;
        private readonly IRequestContentHeaderServices _requestContentHeaderServices;
        private readonly ICheckRequestPermissionServices _checkRequestPermissionServices;
        private readonly INotificationServices _notificationServices;
        private readonly IIncidentRequestServices _incidentRequestServices;
        public CommonQuestionController(IHelpersServices helpersServices, ITicketServices ticketServices, ICheckGroupUserPermissionServices checkGroupUserPermissionServices, ICommonQuestionService questionService, IRequestContentBodyServices requestContentBodyServices, IRequestContentHeaderServices requestContentHeaderServices, ICheckRequestPermissionServices checkRequestPermissionServices, INotificationServices notificationServices, IIncidentRequestServices incidentRequestServices)
        {
            _helpersServices = helpersServices;
            _ticketServices = ticketServices;
            _checkGroupUserPermissionServices= checkGroupUserPermissionServices;
            _QuestionService = questionService;
            _RequestContentBodyServices = requestContentBodyServices;
            _requestContentHeaderServices = requestContentHeaderServices;
            _checkRequestPermissionServices = checkRequestPermissionServices;
            _notificationServices = notificationServices;
            _incidentRequestServices = incidentRequestServices;
    }
        public IActionResult Index(string Questionid, bool isGetDataOnly = false)
        {
            if (!isGetDataOnly)
            {
                return RedirectToAction("Index", "Home");
            }
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
            AddNewQuestionView model = new AddNewQuestionView();
            var ListCategories = _helpersServices.GetCategories();

            var ListDepartment = _helpersServices.GetListDepartments();

            var ListDepartmentHasEmail = ListDepartment.Where(x => !string.IsNullOrEmpty(x.Email)).ToList();
            var ListUserInDepartment = _helpersServices.getListUserInDepartments();
            //var groupedUser = ListUserInDepartment.GroupBy(u => u.DepartmentCode)
            //                                      .Select(grp => new { GroupID = grp.Key, CustomerList = grp.ToList() })
            //                                      .ToList();
            model.categories = ListCategories.ToList();
            model.CurrentEmail = getCurrentUser.Email;
            model.CurrentFullName = getCurrentUser.FullName;
            model.UserName = getCurrentUser.UserName;
            model.Departments = ListDepartmentHasEmail;
            model.UserInDepartments = ListUserInDepartment;
            //model.childCategories = _helpersServices.GetChildCategories().ToList();
            if (!string.IsNullOrEmpty(Questionid))
            {
                    
                    model.Questioninfo = _helpersServices.getRequestById(Questionid) ;
             
                if (model.Questioninfo.Category > 0 && model.Questioninfo.Category != null)
                {
                    int catergoryId = (int)model.Questioninfo.Category;
                    model.CategoryParent = _helpersServices.GetCategoryById(catergoryId).ParentId != null ? (int)_helpersServices.GetCategoryById(catergoryId).ParentId : -1 ;
                }
                else
                {
                    model.CategoryParent = -1;
                }
                    
            }
            else
            {
                model.Questioninfo = null;
            }

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public string AddNewQuestion(string RequestTitle, string RequestContent, User user, int CategoryID, List<IFormFile> files, int Priority, string[] UserAssign, int[] DepartmentAssign, string[] UserFollow, int isPrivate, string IDTicket, string TicketCustomerCode, string TicketContractID, bool IsQuestion= true)
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
            //var getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            var a = _QuestionService.AddnewQuestion(RequestTitle, RequestContent, getCurrentUser, CategoryID, files, Priority, UserAssign, DepartmentAssign, UserFollow, isPrivate, IDTicket, TicketCustomerCode, TicketContractID, IsQuestion);
            //        return RedirectToAction("Index", new RouteValueDictionary(
            //new { controller = "RequestList", action = "Index", notification = "NewRequest" }));
            //throw new AppException("Không tìm thấy tài khoản");
            return "OK";
        }
        [Authorize]
        [HttpPost]
        public string UpdateQuestion(string RequestTitle, string RequestContent, User user, int CategoryID, List<IFormFile> files, int Priority, string[] UserAssign, int[] DepartmentAssign, string[] UserFollow, int isPrivate, string IDTicket, string TicketCustomerCode, string TicketContractID, string QuestionId)
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
            //var getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            var a = _QuestionService.UpdateQuestion(RequestTitle, RequestContent, getCurrentUser, CategoryID, files, Priority, UserAssign, DepartmentAssign, UserFollow, isPrivate, IDTicket, TicketCustomerCode, TicketContractID, QuestionId);
            //        return RedirectToAction("Index", new RouteValueDictionary(
            //new { controller = "RequestList", action = "Index", notification = "NewRequest" }));
            //throw new AppException("Không tìm thấy tài khoản");
            return "OK";
        }
        public IActionResult QuestionList(int? mention, int? pageNumber, string text, string category, string pri, string notification, string createBy, bool isGetData = false)
        {
            if (isGetData)
            {
                var page = pageNumber.HasValue ? pageNumber.Value : 18;
                if (text == "undefined")
                    text = "";
                if (category == "undefined")
                    category = "";
                if (pri == "undefined")
                    pri = "";
                if (notification == "undefined")
                    notification = "";
                if (createBy == "undefined")
                    createBy = "";
                ViewData["Notification"] = string.Empty;

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
                var ListRequest = _QuestionService.GetListQuestion(GroupUserID, UserName, mention, page, text, category, pri);
                var GroupUserPermission = _checkGroupUserPermissionServices.GetGroupUserPermission(GroupUserID);
                ListRequestAndPermission listRequestAndPermission = new ListRequestAndPermission();

                listRequestAndPermission.GroupUserPermission = GroupUserPermission;
                listRequestAndPermission.ListRequest = ListRequest.ListRequestTickets;
                //listRequestAndPermission.MinPage = ListRequest.MinPage;
                //listRequestAndPermission.MaxPage = ListRequest.MaxPage;
                //listRequestAndPermission.TotalItem = ListRequest.TotalRequest; // So trang :)))))
                listRequestAndPermission.TotalItem = ListRequest.TotalQuestion;
                listRequestAndPermission.IsLastItem = ListRequest.isLastItem;
                if (!string.IsNullOrEmpty(notification))
                    ViewData["Notification"] = "NewRequest";
                return View(listRequestAndPermission);
            }
            else
            {
                //activeStatus
                return RedirectToAction("Index", "Home");
            }

        }
        public string RemoveQuestion( string QuestionId)
        {
            return _QuestionService.RemoveQuestion(QuestionId);
        }
        public IActionResult QuestionContent(string RequestID, bool isGetDataOnly = false)
        {
            if (!isGetDataOnly)
            {
                return RedirectToAction("Index", "Home", new { RequestID = RequestID });
            }
            if (string.IsNullOrEmpty(RequestID))
            {
                return null;
            }
            ViewData["RequestID"] = string.Empty;
            if (!string.IsNullOrEmpty(RequestID))
            {
                ViewData["RequestID"] = RequestID;
                HttpContext.Session.SetString("SessionRequestID", JsonConvert.SerializeObject(RequestID));
            }

            //var CurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User CurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                CurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                CurrentUser = _helpersServices.getUserForTest();
            }
            //ViewBag.Username = CurrentUser.UserName;
            

                bool isAdmin = _checkGroupUserPermissionServices.IsAdmin(CurrentUser.GroupUserID);

                var setisReadOnChange = _notificationServices.SetOnChangeIsRead(RequestID, CurrentUser);
                //var getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));

                var GroupUserID = CurrentUser.GroupUserID;
                var CurrentUserName = CurrentUser.UserName;
                var CurrentDepartment = CurrentUser.DepartmentID;

                var FullRequestModel = new ContentRequest();
                var ListUsersAssign = _RequestContentBodyServices.GetUserAssign(RequestID);
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
                var RequestContent = _RequestContentBodyServices.GetRequestComment(RequestID);
                var AttFile = _RequestContentBodyServices.GetAttachFiles(RequestID);
                var ListPrivateChat = _RequestContentBodyServices.GetPrivateChat(RequestID);
                var UserInfomation = _RequestContentBodyServices.GetUserInfomation(RequestID);
                var ListDepartmentsAssign = _RequestContentBodyServices.GetDepartmentAssign(RequestID);
                var ListDepartmentsFollow = _RequestContentBodyServices.GetDepartmentFollow(RequestID);

                var ListUsersFollow = _RequestContentBodyServices.GetUserFollow(RequestID);
                var GroupUserPermission = _checkGroupUserPermissionServices.GetGroupUserPermission(GroupUserID);
                var RenderBtn = _requestContentHeaderServices.RenderButton(RequestID, CurrentDepartment, CurrentUserName);
                var TicketID = _RequestContentBodyServices.GetTicketID(RequestID);
                var TicketCustomerID = _RequestContentBodyServices.GeTicketCustomerID(RequestID);
                var ContractID = _RequestContentBodyServices.GeTicketContractID(RequestID);

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

                //else
                //{
                //    return RedirectToAction("Index", new RouteValueDictionary(
                //        new { controller = "Error", action = "Index", TextNote = "404" }));
                //}
            


        }
    }
}
