using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IModalsServices;
using CSKH_SSP.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.ViewModels.ListRequest;
using CSKH_SSP.Constant;

namespace CSKH_SSP.Services.ModalsServices {
    public class ModalsServices : IModalsServices {
        private DataContext _dataContext;
        public ModalsServices(DataContext dataContext) {
            _dataContext = dataContext;
        }
        public List<DepartmentAssign> GetListDepartments() {
            var listDepartment = from a in _dataContext.Department
                                 select new DepartmentAssign() { DepartmentID = a.DepartmentID, DepartmentCode = a.DepartmentCode, DepartmentName = a.DepartmentName, IsAssignOrFollow = false};

            return listDepartment.ToList();
        }
        
        public List<RequestPermission> GetDepartmentsAssignRequest(string RequestID) {
            var ListDepartment = _dataContext.RequestPermission.Where(x => x.RequestID == RequestID && x.UserName == null && (x.DepartmentID != null || x.DepartmentID != 0) && x.Meta == StringLibrary.DepartmentAssignMetaString);
            return ListDepartment.ToList();
        }
        public List<RequestPermission> GetDepartmentsFollowRequest(string RequestID) {
            var ListDepartment = _dataContext.RequestPermission.Where(x => x.RequestID == RequestID && x.UserName == null && (x.DepartmentID != null || x.DepartmentID != 0) && x.Meta == StringLibrary.DepartmentFollowMetaString);
            return ListDepartment.ToList();
        }
        public List<UserAssign> GetUserOfDepartment(int DepartmentID) {
            var ListUser = (from a in _dataContext.User
                            where a.DepartmentID == DepartmentID
                            select new UserAssign() { UserID = a.UserID, FullName = a.FullName, UserName = a.UserName, IsAssignOrFollow = false }).ToList();
            return ListUser;
        }

        public List<UserAssign> GetUserPermission(int categoryId)
        {
            var ListUser = (from a in _dataContext.User
                            from b in _dataContext.CategoryPermission.Where(x => x.IDCategory == categoryId)
                            where a.UserName == b.UserName
                            select new UserAssign() { UserID = a.UserID, FullName = a.FullName, UserName = a.UserName, IsAssignOrFollow = false }).ToList();
            return ListUser;
        }


        public List<RequestPermission> GetUserAssignRequest(string RequestID) {
            var ListUser = _dataContext.RequestPermission.Where(x => x.RequestID == RequestID && x.UserName != null &&(x.DepartmentID == null || x.DepartmentID == 0)  && (x.Meta == StringLibrary.UserAssignMetaString || x.Meta == StringLibrary.UserAssignMetaStringLv2 || x.Meta == StringLibrary.UserAssignMetaStringLv3));
            return ListUser.ToList();
        }

        public List<RequestPermission> GetUserFollowRequest(string RequestID) {
            var ListUser = _dataContext.RequestPermission.Where(x => x.RequestID == RequestID && x.UserName != null && (x.DepartmentID == null || x.DepartmentID == 0)  && x.Meta == StringLibrary.UserFollowMetaString);
            return ListUser.ToList();
        }

        public List<Category> GetListCategories()
        {
            var ListCategories = _dataContext.Category;
            return ListCategories.ToList();
        }
    }
}
