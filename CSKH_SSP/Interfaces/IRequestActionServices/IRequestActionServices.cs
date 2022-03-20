using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using Microsoft.AspNetCore.Http;

namespace CSKH_SSP.Interfaces.IRequestActionServices
{
    public interface IRequestActionServices
    {
        public string ChangeStatusRequest(string RequestID, int CategoryID, string Status, User user, int ReasonId, bool isAuto = false);
        public string RejectStatus(string RequestID, string NoteReject, User userInformation);
        public string ReplyRequest(string RequestID, string ReplyContent, User UserInfomation, List<IFormFile> files);
        public string EditRequest(string RequestID, int? CategoryID, DateTime? DateFinish, int? Priority);
        public string UpdateDepartmentToAssignRequest(string RequestID, string RequestContent, int[] DepartmentID, User user, bool isAutoAdd = false);
        public string UpdateDepartmentFollowRequest(string RequestID, int[] DepartmentID, User user, bool isAutoAdd = false);
        public string UpdateUserAssignRequest(string RequestID, string RequestContent, string[] UserNameAsssign, User user, bool isAutoAdd = false, int FormLevel = 1);
        public string UpdateUserFollowRequest(string RequestID, string RequestContent, string[] UserNameAsssign, User user, bool isAutoAdd = false);
        public string DeleteUserAssign(string RequestID, string UserName, string level);
        public string DeleteUserFollow(string RequestID, string UserName);
        public string DeleteDepartmentAssign(string RequestID, int DepartmentID);
        public string DeleteDepartmentFollow(string RequestID, int DepartmentID);
        public string FeedBack(string feedBackToRequestID, string feedBackContent, int rating);
        public string SendPrivateChatOrAdvice(string RequestID, string ContentPrivateChat, User CurrentUser, string ToUserName);

    }
}