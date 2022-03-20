using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSKH_SSP.Interfaces;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Interfaces.IModalsServices;
using CSKH_SSP.Interfaces.ICountUserOnlineService;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.ListRequest;

namespace CSKH_SSP.Controllers.ModalsContent
{
    public class ModalContentController : Controller
    {
        private readonly IHelpersServices _helpersServices;
        private readonly IModalsServices _modalsServices;
        private readonly ICountUserOnlineService _iCountUserOnlineService;

        public ModalContentController(IHelpersServices helpersServices, IModalsServices modalsServices, ICountUserOnlineService iCountUserOnlineService)
        {
            _helpersServices = helpersServices;
            _modalsServices = modalsServices;
            _iCountUserOnlineService = iCountUserOnlineService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FilterModal()
        {
            var Obj = _helpersServices.FilterModel();
            return View(Obj);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        public IActionResult StatisticalModal()
        {
            var Obj = _helpersServices.FilterModel();
            return View(Obj);
            //return View();
        }
        public IActionResult GetListDepartment(string RequestID)
        {
            var ListDepartment = _modalsServices.GetListDepartments();
            if (!string.IsNullOrEmpty(RequestID))
            {
                var ListDepartmentAssign = _modalsServices.GetDepartmentsAssignRequest(RequestID);
                foreach (var item in ListDepartmentAssign)
                {
                    foreach (var i in ListDepartment)
                    {
                        if (item.DepartmentID == i.DepartmentID)
                        {
                            i.IsAssignOrFollow = true;
                        }
                    }
                }
            }
            return Ok(ListDepartment);
        }
        public IActionResult GetListDepartmentFollow(string RequestID)
        {
            var ListDepartment = _modalsServices.GetListDepartments();
            if (!string.IsNullOrEmpty(RequestID))
            {
                var ListDepartmentAssign = _modalsServices.GetDepartmentsFollowRequest(RequestID);
                foreach (var item in ListDepartmentAssign)
                {
                    foreach (var i in ListDepartment)
                    {
                        if (item.DepartmentID == i.DepartmentID)
                        {
                            i.IsAssignOrFollow = true;
                        }
                    }
                }
            }
            return Ok(ListDepartment);
        }
        public IActionResult GetUserOfDepartment(int DepartmentID, string RequestID)
        {
            CSKH_SSP.DataModels.User getCurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                getCurrentUser = _helpersServices.getUserForTest();
            }
            //return View(_iCountUserOnlineService.UpdateWhoIsOnline(getCurrentUser.UserID, true));
            var ListUser = _modalsServices.GetUserOfDepartment(DepartmentID);
            var ListUserAssignRequest = _modalsServices.GetUserAssignRequest(RequestID);
            var UserAndStatus = _iCountUserOnlineService.UpdateWhoIsOnline(getCurrentUser.UserID, true);


            foreach (var item in ListUserAssignRequest)
            {
                foreach (var i in ListUser)
                {
                    if (item.UserName == i.UserName)
                    {
                        i.IsAssignOrFollow = true;
                    }
                }
            }

            var list1 = (from a in ListUser
                         join c in UserAndStatus on a.UserName equals c.UserName
                         select new UserAssign()
                         {
                             UserID = a.UserID,
                             UserName = a.UserName,
                             FullName = a.FullName,
                             IsAssignOrFollow = a.IsAssignOrFollow,
                             Status = c.countAllTask > 0 ? c.countAllTask + " task(s)" : "Ready"

                         }).ToList();

            var list2 = (from a in ListUser
                         from c in UserAndStatus 
                         where a.UserName != c.UserName
                         select new UserAssign()
                         {
                             UserID = a.UserID,
                             UserName = a.UserName,
                             FullName = a.FullName,
                             IsAssignOrFollow = a.IsAssignOrFollow,
                             Status = "Ready"

                         }).ToList();
            var res = list1.Concat(list2);

            return Ok(res.GroupBy(x => x.UserName).Select(a => a.First()));
        }

        public IActionResult GetUserPermission(int categoryId, string RequestID)
        {
            CSKH_SSP.DataModels.User getCurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                getCurrentUser = _helpersServices.getUserForTest();
            }
            //return View(_iCountUserOnlineService.UpdateWhoIsOnline(getCurrentUser.UserID, true));
            var ListUser = _modalsServices.GetUserPermission(categoryId);
            var ListUserAssignRequest = _modalsServices.GetUserAssignRequest(RequestID);
            var UserAndStatus = _iCountUserOnlineService.UpdateWhoIsOnline(getCurrentUser.UserID, true);


            foreach (var item in ListUserAssignRequest)
            {
                foreach (var i in ListUser)
                {
                    if (item.UserName == i.UserName)
                    {
                        i.IsAssignOrFollow = true;
                    }
                }
            }

            var list1 = (from a in ListUser
                        
                         select new UserAssign()
                         {
                             UserID = a.UserID,
                             UserName = a.UserName,
                             FullName = a.FullName,
                             IsAssignOrFollow = a.IsAssignOrFollow,
                         }).ToList();

            //var list2 = (from a in ListUser
            //             from c in UserAndStatus
            //             where a.UserName != c.UserName
            //             select new UserAssign()
            //             {
            //                 UserID = a.UserID,
            //                 UserName = a.UserName,
            //                 FullName = a.FullName,
            //                 IsAssignOrFollow = a.IsAssignOrFollow,
            //                 Status = "Ready"

            //             }).ToList();
            //var res = list1.Concat(list2);

            return Ok(list1.GroupBy(x => x.UserName).Select(a => a.First()));
        }

        public IActionResult GetListCategories()
        {
            var ListCategories = _modalsServices.GetListCategories();
            return Ok(ListCategories);
        }
    }
}