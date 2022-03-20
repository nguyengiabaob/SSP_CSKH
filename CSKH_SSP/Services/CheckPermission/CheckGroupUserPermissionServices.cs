using CSKH_SSP.Interfaces.ICheckPermission;
using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Services.CheckPermission {
    public class CheckGroupUserPermissionServices : ICheckGroupUserPermissionServices {
        private DataContext _dataContext;
        public CheckGroupUserPermissionServices(DataContext dataContext) {
            _dataContext = dataContext;
        }
        public GroupUserPermission GetGroupUserPermission(int GroupUserID) {
            var Permission = _dataContext.GroupUserPermission.Where(x => x.GroupUserID == GroupUserID).First();
            return Permission;
        }
        public bool IsAdmin(int GroupUserID)
        {
            if (GroupUserID == 1)
                return true;
            return false;
        }
        public bool IsStaff(int GroupUserID)
        {
            if (GroupUserID == 2 || GroupUserID == 4)
                return true;
            return false;
        }
        public bool IsUserCreatedRequest(string RequestID, string UserName)
        {
            var temp = _dataContext.Request.Where(x => x.RequestID == RequestID).Select(x => x.createByUserName).First();
            if (temp == UserName)
                return true;
            return false;
        }
    }
}
