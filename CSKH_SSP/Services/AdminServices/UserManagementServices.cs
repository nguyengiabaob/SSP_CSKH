using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IAdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Services.AdminServices
{
    public class UserManagementServices : IUserManagementServices
    {
        private DataContext _dataContext;

        public UserManagementServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string AddNewUser(User user) {
            //OrderByDescending
            var CurrentUserID = _dataContext.User.OrderByDescending(x => x.UserID).Select(x => x.UserID).FirstOrDefault();
            var UserID = CurrentUserID + 1;
            if(_dataContext.User.Count(x => x.UserName == user.UserName) > 0)
            {
                return null;
            }
            User userObject = new User();
            userObject.UserID = UserID;
            userObject.Password = "$2a$10$tkZFVpvhSmo3QY.0tEMHEeI4Yqx6QAMM71oYoCRTzesfKhVmVSXLW";
            userObject.UserName = user.UserName;
            userObject.FullName = user.FullName;
            userObject.Email = user.Email;
            userObject.Avt = "bo.png";
            userObject.DepartmentID = user.DepartmentID;
            userObject.GroupUserID = user.GroupUserID;
            _dataContext.User.Add(userObject);
            _dataContext.SaveChanges();
            return "aa";
        }
    }
}
