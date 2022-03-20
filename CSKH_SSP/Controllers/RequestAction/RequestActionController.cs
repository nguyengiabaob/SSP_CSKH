using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using CSKH_SSP.Interfaces.IRequestActionServices;
using System.ComponentModel.Design;
using CSKH_SSP.Interfaces.IHelpersServices;

namespace CSKH_SSP.Controllers.ChangeStatus
{

    public class RequestActionController : Controller
    {
        private readonly IRequestActionServices _requestActionServices;
        private readonly IHelpersServices _helpersServices;

        public RequestActionController(IRequestActionServices requestActionServices, IHelpersServices helpersServices)
        {
            _requestActionServices = requestActionServices;
            _helpersServices = helpersServices;
        }

        public string ChangeStatusRequest(string RequestID, int CategoryID, string Status, int ReasonId)
        {
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

            return _requestActionServices.ChangeStatusRequest(RequestID, CategoryID, Status, getCurrentUser, ReasonId);
        }

        [HttpPost]
        public String RejectStatus(string RequestID, string NoteReject)
        {
            //var a = _requestActionServices.RejectStatus(RequestID, NoteReject);
            var getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));

            _requestActionServices.RejectStatus(RequestID, NoteReject, getCurrentUser);
            return "OK";
            //return RedirectToAction("RequestContent", new RouteValueDictionary(
            //new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));
        }

        public IActionResult FeedBack(string feedBackToRequestID, string feedBackContent, int rating)
        {
            var a = _requestActionServices.FeedBack(feedBackToRequestID, feedBackContent, rating);
            if(a == "1")
            {
                return Ok("OK");
            } else
            {
                return Ok("False");
            }
        }



        public IActionResult ReplyRequest(string RequestID, string ReplyContent, List<IFormFile> files)
        {
            if (ReplyContent == null)
            {
                //return "Vui lòng nhập nội dung trả lời";
                return RedirectToAction("Index", "Error", new { @TextNote = "Vui lòng nhập nội dung trả lời" });
                //              return RedirectToAction("Index", new RouteValueDictionary(
                //new { controller = "Error", action = "Index", TextNote = "Vui lòng nhập nội dung trả lời" }));
            }
            //var UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User UserInfomation;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                UserInfomation = _helpersServices.getUserForTest();
            }

            var result = _requestActionServices.ReplyRequest(RequestID, ReplyContent, UserInfomation, files);

            //if (result == "OK")
            //    return "Thành công";
            //else
            //    return "Lỗi";

            return Ok("OK");
            //    return RedirectToAction("RequestContent", new RouteValueDictionary(
            //new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));

            //return RedirectToAction("RequestContent", new RouteValueDictionary(
            //new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));
        }
        public IActionResult SendPrivateChatOrAdvice(string RequestID, string ContentPrivateChat, string ToUserName)
        {
            //var CurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User UserInfomation;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                UserInfomation = _helpersServices.getUserForTest();
            }

            var result = _requestActionServices.SendPrivateChatOrAdvice(RequestID, ContentPrivateChat, UserInfomation, ToUserName);
            if (result == "OK")
                return Ok("OK");
            //    return RedirectToAction("RequestContent", new RouteValueDictionary(
            //new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));
            return RedirectToAction("RequestContent", new RouteValueDictionary(
            new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));
        }
        public IActionResult EditRequest(string RequestID, int? CategoryID, DateTime? DateFinish, int? Priority)
        {
            var result = _requestActionServices.EditRequest(RequestID, CategoryID, DateFinish, Priority);
            if (result == "OK")
                return Ok("OK");
            //return RedirectToAction("RequestContent", new RouteValueDictionary(
            //new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));
            return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Error", action = "Index", TextNote = "Lỗi. Vui lòng thử lại" }));
        }

        [HttpPost]
        public string UpdateDepartmentAssignRequest(string RequestID, int[] DepartmentID, string ContentRequest)
        {
            //var UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User UserInfomation;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                UserInfomation = _helpersServices.getUserForTest();
            }

            var result = _requestActionServices.UpdateDepartmentToAssignRequest(RequestID, ContentRequest, DepartmentID, UserInfomation);
            if (result == "OK")
                return "OK";
            return "False";
            //return RedirectToAction("RequestContent", new RouteValueDictionary(
            //    new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));
            //return RedirectToAction("Index", new RouteValueDictionary(
            //    new { controller = "Error", action = "Index", TextNote = "Lỗi. Vui lòng thử lại" }));
        }

        [HttpPost]
        public IActionResult UpdateUserAssignRequest(string RequestID, string[] UserAsssign, string ContentRequest, int FormLevel)
        {
            //var UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User UserInfomation;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                UserInfomation = _helpersServices.getUserForTest();
            }

            var result = _requestActionServices.UpdateUserAssignRequest(RequestID, ContentRequest, UserAsssign, UserInfomation, false,FormLevel);
            if (result == "OK")
                return Ok("OK");
            //return RedirectToAction("RequestContent", new RouteValueDictionary(
            //    new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));
            return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Error", action = "Index", TextNote = "Lỗi. Vui lòng thử lại" }));
        }

        [HttpPost]
        public IActionResult UpdateUserFollowRequest(string RequestID, string[] UserFollow, string ContentRequest)
        {
            //var UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User UserInfomation;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                UserInfomation = _helpersServices.getUserForTest();
            }

            var result = _requestActionServices.UpdateUserFollowRequest(RequestID, ContentRequest, UserFollow, UserInfomation);
            if (result == "OK")
                return Ok("OK");
            //return RedirectToAction("RequestContent", new RouteValueDictionary(
            //    new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));
            return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Error", action = "Index", TextNote = "Lỗi. Vui lòng thử lại" }));
        }

        [HttpPost]
        public IActionResult UpdateDepartmentFollowRequest(string RequestID, int[] DepartmentID)
        {
            //var UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            CSKH_SSP.DataModels.User UserInfomation;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                UserInfomation = _helpersServices.getUserForTest();
            }
            var result = _requestActionServices.UpdateDepartmentFollowRequest(RequestID, DepartmentID, UserInfomation);
            if (result == "OK")
                return Ok("OK");
            //return RedirectToAction("RequestContent", new RouteValueDictionary(
            //    new { controller = "RequestContent", action = "RequestContent", RequestID = RequestID }));
            return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Error", action = "Index", TextNote = "Lỗi. Vui lòng thử lại" }));
        }

        public string DeleteUserAssign(string RequestID, string UserName, string level)
        {
            var result = _requestActionServices.DeleteUserAssign(RequestID, UserName, level);
            if (result == "OK")
                if (result == "OK")
                    return "OK";
            return "Lỗi, vui lòng thử lại";
        }
        public string DeleteUserFollow(string RequestID, string UserName)
        {
            var result = _requestActionServices.DeleteUserFollow(RequestID, UserName);
            if (result == "OK")
                return "OK";
            return "Lỗi, vui lòng thử lại";
        }
        public string DeleteDepartmentAssign(string RequestID, int Department)
        {
            var result = _requestActionServices.DeleteDepartmentAssign(RequestID, Department);
            if (result == "OK")
                if (result == "OK")
                    return "OK";
            return "Lỗi, vui lòng thử lại";
        }
        public string DeleteDepartmentFollow(string RequestID, int Department)
        {
            var result = _requestActionServices.DeleteDepartmentFollow(RequestID, Department);
            if (result == "OK")
                if (result == "OK")
                    return "OK";
            return "Lỗi, vui lòng thử lại";
        }
        public string PinRequest(string RequestID)
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
            return _helpersServices.PinRequest(RequestID, getCurrentUser.UserName);
        }

    }
}