using CSKH_SSP.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.ICheckPermission {
    public interface ICheckGroupUserPermissionServices {
        public GroupUserPermission GetGroupUserPermission(int GroupUserID);
        public bool IsStaff(int GroupUserID);
        public bool IsAdmin(int GroupUserID);
        public bool IsUserCreatedRequest(string RequestID, string UserName);
    }
}
