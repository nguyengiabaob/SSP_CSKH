using CSKH_SSP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Helpers;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.ContentRequest;
using CSKH_SSP.ViewModels.ContentRequest.Header;
using CSKH_SSP.Constant;
using CSKH_SSP.Interfaces.ICheckPermission;

namespace CSKH_SSP.Services.Request.RequestContent
{
    public class RequestContentHeaderServices : IRequestContentHeaderServices
    {
        private readonly DataContext _dataContext;
        private readonly ICheckGroupUserPermissionServices _checkGroupUserPermissionServices;
        private readonly ICheckRequestPermissionServices _checkRequestPermissionPermission;

        public RequestContentHeaderServices(DataContext dataContext, ICheckGroupUserPermissionServices checkGroupUserPermissionServices, ICheckRequestPermissionServices checkRequestPermissionPermission)
        {
            _dataContext = dataContext;
            _checkGroupUserPermissionServices = checkGroupUserPermissionServices;
            _checkRequestPermissionPermission = checkRequestPermissionPermission;
        }
        public ContentRequestHeader GetInfoRequest(string ReqID, string UserName)
        {
            ContentRequestHeader RequestInfo = new ContentRequestHeader();
            if (string.IsNullOrEmpty(ReqID))
            {
                return RequestInfo;
            }
            RequestInfo = (from a in _dataContext.Request
                           from b in _dataContext.Category
                           where a.RequestID == ReqID && a.Category == b.IDCategory
                           select new ContentRequestHeader { RequestID = a.RequestID, RequestStatus = a.RequestStatus, RequestTittle = a.RequestTittle, RequestAuthor = a.RequestAuthorFullName, RequestDay = a.RequestDay, FinishDay = a.FinishTime, CategoryID = b.IDCategory, RequestCategory = b.CategoryName, RequestPriority = a.Priority ?? 2, attFile = a.hasAttFile ?? false, TimeDone = a.TimeDone, ListCCMail = a.listCCMail, ListMailTo = a.listMailTo, RequestNotes = a.RequestNotes, Feedback = a.Feedback, Rating = a.Rating, createByUserName = a.createByUserName, IsQuestion = a.IsQuestion }).First();
            
            return RequestInfo;
        }
        public RenderButton RenderButton(string RequestID, int CurrentDepartmentID, string UserName)
        {
            var CurrentUserObj = _dataContext.User.Where(x => x.UserName == UserName).First();
            RenderButton obj = new RenderButton();
            var RequestTemp = _dataContext.Request.Where(x => x.RequestID == RequestID).First();
            var ListUserCanReply = _checkRequestPermissionPermission.ListUserCanReply(RequestID, CurrentDepartmentID, UserName);
            bool isCanReply = ListUserCanReply.Any(x => x.UserName == UserName);

            var UserCanFinish = _checkRequestPermissionPermission.CheckFinishOrCloseRequestPermission(RequestID, CurrentUserObj.GroupUserID, CurrentUserObj.DepartmentID, UserName);
            bool iSAdmin = _checkGroupUserPermissionServices.IsAdmin(_dataContext.User.Where(x => x.UserName == UserName).Select(x => x.GroupUserID).First());
            if ((RequestTemp.RequestStatus == StringLibrary.RequestStatusProcessing && isCanReply) || (RequestTemp.RequestStatus == StringLibrary.RequestStatusProcessing && iSAdmin))
            {
                obj.ReplyRequestBtn = true;
                //obj.FinishBtn = true;
                obj.RejectBtn = true;
                obj.NoteAndPrivateChatBtn = true;
            }
            if ((RequestTemp.RequestStatus == StringLibrary.RequestStatusProcessing && UserCanFinish && RequestTemp.RequestStatus != StringLibrary.RequestStatusClosed) || (iSAdmin && RequestTemp.RequestStatus != StringLibrary.RequestStatusClosed && RequestTemp.RequestStatus == StringLibrary.RequestStatusProcessing))
            {
                obj.FinishBtn = true;
            }
            if (RequestTemp.RequestStatus == StringLibrary.RequestStatusOpen)
            {
                obj.ReceiveRequestBtn = true;
                obj.NoteAndPrivateChatBtn = true;
                obj.RejectBtn = true;
            }
            
            if(_dataContext.RequestIncident.Count(x => x.RequestId == RequestID) > 0)
                obj.IncidentBtn = false;
            else
                obj.IncidentBtn = true;
            return obj;
        }
    }
}
