using CSKH_SSP.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.ICheckPermission
{
    public interface ICheckRequestPermissionServices
    {
        public bool CheckReceiveRequestPermission(string UserName, int CurrentDepartmentID, int GroupUserID, string RequestID, int CategoryID);
        public IEnumerable<CategoryPermission> ListUserForThisCategory(int IDCategory);
        public IEnumerable<RequestPermission> ListDepartmentForThisRequest(string RequestID);
        public IEnumerable<User> ListUserCanViewRequest(string RequestID, int CurrentDepartmentID, string UserName);
        public IEnumerable<User> ListUserCanReply(string RequestID, int CurrentDepartmentID, string UserName);
        public bool CheckFinishOrCloseRequestPermission(string RequestID, int GroupUserID, int CurrentDepartmentID, string UserName);
    }
}
