using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Interfaces.IAdminActionServices;
using Microsoft.AspNetCore.Mvc;

namespace CSKH_SSP.Controllers.AdminArea
{
    public class AdminActionController : Controller
    {
        private readonly IAdminActionServices _adminActionServices;

        public AdminActionController(IAdminActionServices adminActionServices)
        {
            _adminActionServices = adminActionServices;
        }

        public string DisableCategory(string status)
        {
            return _adminActionServices.DisableCategory(status);
        }
        public string SetPermission(string[] Username, int GroupUserID)
        {
            return _adminActionServices.SetPermission(Username, GroupUserID);
        }
        public string DeletePermission(string Username)
        {
            return _adminActionServices.DeletePermission(Username);

        }

        public string AddCategory(string CategoryName)
        {
            return _adminActionServices.AddCategory(CategoryName);
        }
        public IActionResult Index()
        {
            return View();
        }


        public string AddUserToCategory(string[] Username, int CategoryId)
        {
            return _adminActionServices.AddUserToCategory(Username, CategoryId);
        }
        public string DeleteUserFromCategory(string Username, int CategoryId)
        {
            return _adminActionServices.DeleteUserFromCategory(Username, CategoryId);
        }
        public string SetHoursDeadline(int hours, int hourResolve, int CategoryId)
        {
            return _adminActionServices.SetHoursDeadline(hours, hourResolve, CategoryId);
        }

    }
}
