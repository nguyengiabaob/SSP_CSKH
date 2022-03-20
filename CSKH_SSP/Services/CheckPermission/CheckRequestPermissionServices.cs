using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CSKH_SSP.Constant;
using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces;
using CSKH_SSP.Interfaces.ICheckPermission;

namespace CSKH_SSP.Services.CheckPermission
{
    public class CheckRequestPermissionServices : ICheckRequestPermissionServices
    {
        private readonly DataContext _dataContext;
        private readonly ICheckGroupUserPermissionServices _checkGroupUserPermissionServices;

        public CheckRequestPermissionServices(DataContext dataContext, ICheckGroupUserPermissionServices checkGroupUserPermissionServices)
        {
            _dataContext = dataContext;
            _checkGroupUserPermissionServices = checkGroupUserPermissionServices;
        }
        public bool CheckReceiveRequestPermission(string UserName, int CurrentDepartmentID, int GroupUserID, string RequestID, int CategoryID)
        {
            var listUserForThisCategory = ListUserForThisCategory(CategoryID);
            bool PermissionThisCategory = listUserForThisCategory.Any(x => x.UserName == UserName);

            var ListDepartmentPermission = ListDepartmentForThisRequest(RequestID);
            bool PermissionDepartmentThisRequest = ListDepartmentPermission.Any(x => x.DepartmentID == CurrentDepartmentID);

            bool isAdmin = _checkGroupUserPermissionServices.IsAdmin(GroupUserID);

            if (PermissionThisCategory || PermissionDepartmentThisRequest || isAdmin)
                return true;
            return false;
        }

        public bool CheckFinishOrCloseRequestPermission(string RequestID, int GroupUserID, int CurrentDepartmentID, string UserName)
        {
            bool isAdmin = _checkGroupUserPermissionServices.IsAdmin(GroupUserID);

            var ListUserCanReplyRequest = ListUserCanReply(RequestID, CurrentDepartmentID, UserName);
            bool isUserCanFinishOrCloseThisRequest = ListUserCanReplyRequest.Any(x => x.UserName == UserName);

            var listUserIn_CSKH = _dataContext.User.Where(x => x.DepartmentID == 15);
            bool isUserIn_CSKH = listUserIn_CSKH.Any(x => x.UserName == UserName);


            if (/*isUserIn_CSKH ||*/ isAdmin || isUserCanFinishOrCloseThisRequest)
                return true;
            return false;
        }

        public IEnumerable<CategoryPermission> ListUserForThisCategory(int IDCategory)
        {
            return _dataContext.CategoryPermission.Where(x => x.IDCategory == IDCategory);
        }
        public IEnumerable<RequestPermission> ListDepartmentForThisRequest(string RequestID)
        {
            return _dataContext.RequestPermission.Where(x => x.RequestID == RequestID && (x.DepartmentID != null || x.DepartmentID != 0) && x.UserName == null);
        }
        public IEnumerable<User> ListUserCanViewRequest(string RequestID, int CurrentDepartmentID, string UserName)
        {
            var UserIdInPrequestPermission = _dataContext.RequestPermission.Where(x => x.RequestID == RequestID && x.UserName == UserName && (x.DepartmentID == null || x.DepartmentID == 0)).Select(x => x.UserName);
            var ListUserID_1 = from a in UserIdInPrequestPermission
                               from c in _dataContext.User
                               where a == c.UserName
                               select new User { UserID = c.UserID, UserName = c.UserName, GroupUserID = c.GroupUserID, Avt = c.Avt };
            var DepartmentIdInPrequestPermission = _dataContext.RequestPermission.Where(x => x.RequestID == RequestID && x.UserName == null && x.DepartmentID == CurrentDepartmentID).Select(x => x.DepartmentID);
            var ListUserID_2 = from a in DepartmentIdInPrequestPermission
                               from c in _dataContext.User
                               where a == c.DepartmentID
                               select new User { UserID = c.UserID, UserName = c.UserName, GroupUserID = c.GroupUserID, Avt = c.Avt };
            var UserCreateRequest = _dataContext.Request.Where(x => x.RequestID == RequestID && x.createByUserName == UserName).Select(x => x.createByUserName);
            var ListUserID_3 = from a in UserCreateRequest
                               from c in _dataContext.User
                               where a == c.UserName
                               select new User { UserID = c.UserID, UserName = c.UserName, GroupUserID = c.GroupUserID, Avt = c.Avt };
            var finalList = ListUserID_1.Concat(ListUserID_2).Concat(ListUserID_3).Distinct();
            return finalList;
        }

        public IEnumerable<User> ListUserCanReply(string RequestID, int CurrentDepartmentID, string UserName)
        {
            var UserIdInPrequestPermission = _dataContext.RequestPermission.Where(x => x.RequestID == RequestID && x.UserName == UserName && (x.DepartmentID == null || x.DepartmentID == 0) && (x.Meta == StringLibrary.UserAssignMetaString || x.Meta == StringLibrary.UserAssignMetaStringLv2 || x.Meta == StringLibrary.UserAssignMetaStringLv3 || x.Meta == StringLibrary.UserCreateRequestMetaString)).Select(x => x.UserName);
            var ListUserID_1 = from a in UserIdInPrequestPermission
                               from c in _dataContext.User
                               where a == c.UserName
                               select new User { UserID = c.UserID, UserName = c.UserName, GroupUserID = c.GroupUserID, Avt = c.Avt };
            var DepartmentIdInPrequestPermission = _dataContext.RequestPermission.Where(x => x.RequestID == RequestID && x.UserName == null && x.DepartmentID == CurrentDepartmentID && x.Meta == StringLibrary.DepartmentAssignMetaString).Select(x => x.DepartmentID);
            var ListUserID_2 = from a in DepartmentIdInPrequestPermission
                               from c in _dataContext.User
                               where a == c.DepartmentID
                               select new User { UserID = c.UserID, UserName = c.UserName, GroupUserID = c.GroupUserID, Avt = c.Avt };
            var UserCreateRequest = _dataContext.Request.Where(x => x.RequestID == RequestID && x.createByUserName == UserName).Select(x => x.createByUserName);
            var ListUserID_3 = from a in UserCreateRequest
                               from c in _dataContext.User
                               where a == c.UserName
                               select new User { UserID = c.UserID, UserName = c.UserName, GroupUserID = c.GroupUserID, Avt = c.Avt };
            

            var finalList = ListUserID_1.Concat(ListUserID_2).Concat(ListUserID_3).Distinct();
            return finalList;
        }

    }
}
