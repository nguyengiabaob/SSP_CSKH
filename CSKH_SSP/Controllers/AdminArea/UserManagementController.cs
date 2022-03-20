using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces.IAdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSKH_SSP.Controllers.AdminArea
{
    [Authorize]
    public class UserManagementController : Controller
    {
        private readonly IUserManagementServices _userManagementServices;

        public UserManagementController(IUserManagementServices userManagementServices)
        {
            _userManagementServices = userManagementServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string AddNewUser()
        {
            var user = new User();
            user.UserName = "MyVTT";
            user.FullName = "MyVTT";
            user.GroupUserID = 1;
            user.Email = "myvntt@vntt.com.vn";
            user.DepartmentID = 441;
            return _userManagementServices.AddNewUser(user);
        }
    }
}
