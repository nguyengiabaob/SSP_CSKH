using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Interfaces.IHelpersServices;
using Microsoft.AspNetCore.Mvc;

namespace CSKH_SSP.Controllers.UserPermission
{
    public class UserPermissionController : Controller
    {
        private readonly IHelpersServices _helpersServices;

        public UserPermissionController(IHelpersServices helpersServices)
        {
            _helpersServices = helpersServices;
        }

        public IActionResult Index()
        {
            var listUser = _helpersServices.getListUserInDepartments();
            return View(listUser);
        }
    }
}
