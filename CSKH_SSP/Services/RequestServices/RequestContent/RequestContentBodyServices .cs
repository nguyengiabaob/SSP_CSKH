using CSKH_SSP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Helpers;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.ContentRequest;
using CSKH_SSP.ViewModels.UserInfomation;
using CSKH_SSP.Constant;
using Microsoft.AspNetCore.Authorization;
using CSKH_SSP.Interfaces.IAdminServices;

namespace CSKH_SSP.Services
{
    [Authorize]
    public class RequestContentBodyServices : IRequestContentBodyServices
    {
        private readonly DataContext _dataContext;
        private readonly IUserManagementServices _userManagementServices;


        public RequestContentBodyServices(DataContext dataContext, IUserManagementServices userManagementServices)
        {
            _dataContext = dataContext;
            _userManagementServices = userManagementServices;
        }
        public string GetTicketID(string RequestID)
        {
            return _dataContext.Request.Where(x => x.RequestID == RequestID).Select(x => x.TicketID).FirstOrDefault();
        }
        public string GeTicketCustomerID(string RequestID)
        {
            return _dataContext.Request.Where(x => x.RequestID == RequestID).Select(x => x.TicketCustomerID).FirstOrDefault();
        }

        public string GeTicketContractID(string RequestID)
        {
            return _dataContext.Request.Where(x => x.RequestID == RequestID).Select(x => x.ContractID).FirstOrDefault();
        }

        public List<ContentRequestBody> GetRequestComment(string RequestID)
        {
            var RequestComment = (from contentEmail in _dataContext.RequestContent
                                  join user in _dataContext.User on contentEmail.UserName equals user.UserName
                                  into ps
                                  from user in ps.DefaultIfEmpty()
                                  where contentEmail.RequestID == RequestID && contentEmail.ContentRequest != null
                                  select new ContentRequestBody
                                  {
                                      ID = contentEmail.ID,
                                      KeyReq = contentEmail.RequestID,
                                      UID = contentEmail.UID,
                                      IDEmail = contentEmail.IDEmail,
                                      RequestTitle = contentEmail.TitleRequest,
                                      RequestContent = contentEmail.ContentRequest,
                                      AuthorEmail = contentEmail.AuthorEmail,
                                      AuthorFullName = contentEmail.AuthorFullName,
                                      CCEmail = contentEmail.CCEmail,
                                      Time = contentEmail.DateTime ?? DateTime.Now,
                                      Status = contentEmail.Status,
                                      IsStaff = contentEmail.IsStaff,
                                      IsTimelinePoint = contentEmail.IsTimelinePoint,
                                      UserName = contentEmail.UserName,
                                      AvtUser = user.Avt,
                                      //isDone = contentEmail.
                                  }).OrderByDescending(c => c.ID).ToList();
            return RequestComment;
        }
        public List<AttachFile> GetAttachFiles(string RequestID)
        {
            //var AttFile = (from a in _dataContext.RequestContent
            //               join b in _dataContext.AttachFile on a.ID equals b.IDComment
            //               where a.RequestID == RequestID
            //               select new CommentAndAttachFile() {
            //                   AttchFile = b,
            //                   Comment = a
            //               }).ToList();
            //return AttFile;
            var AttFile = _dataContext.AttachFile.Where(x => x.IDRequest == RequestID).ToList();
            return AttFile;
        }
        public List<PrivateChat> GetPrivateChat(string RequestID)
        {
            var ListPrivateChat = (from content in _dataContext.RequestContent
                                   from advice in _dataContext.Advice
                                   where advice.CommentID == content.ID && advice.RequestID == RequestID
                                   select new PrivateChat { ID = content.ID, RequestID = content.RequestID, TitleRequest = content.TitleRequest, ContentRequest = content.ContentRequest, AuthorFullName = content.AuthorFullName, DateTime = content.DateTime }).OrderByDescending(x => x.DateTime).ToList();
            return ListPrivateChat;
        }
        public UserCreateRequestInfomation GetUserInfomation(string RequestID)
        {
            UserCreateRequestInfomation userInfomation = new UserCreateRequestInfomation();
            try
            {
                var UserCreateRequest = _dataContext.Request.Where(x => x.RequestID == RequestID).Select(x => x.createByUserName).First();
                var tempUser = _dataContext.User.Where(x => x.UserName == UserCreateRequest).FirstOrDefault();
                if (tempUser == null)
                {
                    var user = new User();
                    user.UserName = UserCreateRequest;
                    user.FullName = UserCreateRequest;
                    user.GroupUserID = 2;
                    user.Email = UserCreateRequest;
                    user.DepartmentID = 999;
                    _userManagementServices.AddNewUser(user);
                    userInfomation.UserName = UserCreateRequest;
                    userInfomation.FullName = UserCreateRequest;
                    userInfomation.Department = "Không xác định";

                }
                else
                {
                    userInfomation.UserName = tempUser.UserName;
                    userInfomation.FullName = tempUser.FullName;
                    var DepartmentName = _dataContext.Department.Where(x => x.DepartmentID == tempUser.DepartmentID).First();
                    userInfomation.Department = DepartmentName.DepartmentName;
                }

                userInfomation.TotalRequest = _dataContext.Request.Count(x => x.createByUserName == UserCreateRequest);

                return userInfomation;
            }
            catch (Exception e)
            {
                var a = e;
                return userInfomation;
            }


        }

        public IEnumerable<Department> GetDepartmentAssign(string RequestID)
        {
            var listDepartmentID = _dataContext.RequestPermission.Where(x => (x.DepartmentID != null || x.DepartmentID != 0) && string.IsNullOrEmpty(x.UserName) && x.RequestID == RequestID && x.Meta == StringLibrary.DepartmentAssignMetaString).ToList();
            var listDerpatment = from DepartmentID in listDepartmentID
                                 from DepartmentObj in _dataContext.Department
                                 where DepartmentID.DepartmentID == DepartmentObj.DepartmentID
                                 select new Department { DepartmentID = DepartmentObj.DepartmentID, DepartmentCode = DepartmentObj.DepartmentCode, DepartmentName = DepartmentObj.DepartmentName };
            return listDerpatment;
        }
        public IEnumerable<Department> GetDepartmentFollow(string RequestID)
        {
            var listDepartmentID = _dataContext.RequestPermission.Where(x => (x.DepartmentID != null || x.DepartmentID != 0) && x.UserName == null && x.RequestID == RequestID && x.Meta == StringLibrary.DepartmentFollowMetaString).ToList();
            var listDerpatment = from DepartmentID in listDepartmentID
                                 from DepartmentObj in _dataContext.Department
                                 where DepartmentID.DepartmentID == DepartmentObj.DepartmentID
                                 select new Department { DepartmentID = DepartmentObj.DepartmentID, DepartmentCode = DepartmentObj.DepartmentCode, DepartmentName = DepartmentObj.DepartmentName };
            return listDerpatment;
        }

        public IEnumerable<User> GetUserAssign(string RequestID)
        {
            var listUserID = _dataContext.RequestPermission.Where(x => (x.DepartmentID == null || x.DepartmentID == 0) && !string.IsNullOrEmpty(x.UserName) && x.RequestID == RequestID && (x.Meta == StringLibrary.UserAssignMetaString || x.Meta == StringLibrary.UserAssignMetaStringLv2 || x.Meta == StringLibrary.UserAssignMetaStringLv3)).ToList();
            var listUser = from UserID in listUserID
                           from UserObj in _dataContext.User
                           where UserID.UserName == UserObj.UserName
                           select new User { UserName = UserObj.UserName, FullName = UserObj.FullName, DepartmentID = (UserID.Meta == StringLibrary.UserAssignMetaString ? 1 : UserID.Meta == StringLibrary.UserAssignMetaStringLv2 ? 2 : 3) };
            return listUser;
        }
        public IEnumerable<User> GetUserFollow(string RequestID)
        {
            var listUserID = _dataContext.RequestPermission.Where(x => (x.DepartmentID == null || x.DepartmentID == 0) && !string.IsNullOrEmpty(x.UserName) && x.RequestID == RequestID && x.Meta == StringLibrary.UserFollowMetaString).ToList();
            var listUser = from UserID in listUserID
                           from UserObj in _dataContext.User
                           where UserID.UserName == UserObj.UserName
                           select new User { UserName = UserObj.UserName, FullName = UserObj.FullName };
            return listUser;
        }



    }
}
