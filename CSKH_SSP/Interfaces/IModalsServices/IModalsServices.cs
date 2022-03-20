using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.ListRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.IModalsServices
{
    public interface IModalsServices
    {
        public List<DepartmentAssign> GetListDepartments();
        public List<RequestPermission> GetDepartmentsAssignRequest(string RequestID);
        public List<RequestPermission> GetDepartmentsFollowRequest(string RequestID);
        public List<UserAssign> GetUserOfDepartment(int DepartmentID);
        public List<UserAssign> GetUserPermission(int categoryId);
        public List<RequestPermission> GetUserAssignRequest(string RequestID);
        public List<Category> GetListCategories();
    }
}
