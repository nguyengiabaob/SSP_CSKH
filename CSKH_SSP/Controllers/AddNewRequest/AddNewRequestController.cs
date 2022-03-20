using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces.IAddNewRequestServices;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Interfaces.ITicketServices;
using CSKH_SSP.ViewModels.AddNewRequest;
using CSKH_SSP.ViewModels.TicketArea;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace CSKH_SSP.Controllers.AddNewRequest
{
    [Authorize]
    public class AddNewRequestController : Controller
    {
        private readonly IHelpersServices _helpersServices;
        private readonly IAddNewRequestServices _addNewRequestServices;
        private readonly ITicketServices _ticketServices;
        public AddNewRequestController(IHelpersServices helpersServices, IAddNewRequestServices addNewRequestServices, ITicketServices ticketServices)
        {
            _helpersServices = helpersServices;
            _addNewRequestServices = addNewRequestServices;
            _ticketServices = ticketServices;
        }
       
        public IActionResult Index(string ticketid, bool isGetDataOnly = false)
        {
            if (!isGetDataOnly)
            {
                return RedirectToAction("Index", "Home", new { TicketID = ticketid });
            }
            CSKH_SSP.DataModels.User getCurrentUser;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                getCurrentUser = _helpersServices.getUserForTest();
            }

            //ViewBag.Username = getCurrentUser.UserName;
            AddNewRequestView model = new AddNewRequestView();
            var ListCategories = _helpersServices.GetCategories();

            var ListDepartment = _helpersServices.GetListDepartments();

            var ListDepartmentHasEmail = ListDepartment.Where(x => !string.IsNullOrEmpty(x.Email) ).ToList();
            var ListUserInDepartment = _helpersServices.getListUserInDepartments();
            //var groupedUser = ListUserInDepartment.GroupBy(u => u.DepartmentCode)
            //                                      .Select(grp => new { GroupID = grp.Key, CustomerList = grp.ToList() })
            //                                      .ToList();
            model.categories = ListCategories.ToList();
            model.CurrentEmail = getCurrentUser.Email;
            model.CurrentFullName = getCurrentUser.FullName;
            model.UserName = getCurrentUser.UserName;
            model.Departments = ListDepartmentHasEmail;
            model.UserInDepartments = ListUserInDepartment;
            //model.childCategories = _helpersServices.GetChildCategories().ToList();
            if (!string.IsNullOrEmpty(ticketid))
            {
                if (_helpersServices.checkTicketIdIsAvailable(ticketid))
                    model.TicketId = ticketid;
                else
                    model.TicketId = "404";
            }
            else
            {
                model.TicketId = "NULL";
            }

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public string AddNewRequest(string RequestTitle, string RequestContent, User user, int CategoryID, List<IFormFile> files, int Priority, string[] UserAssign, int[] DepartmentAssign, string[] UserFollow, int isPrivate, string IDTicket, string TicketCustomerCode, string TicketContractID)
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
            //var getCurrentUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            var a = _addNewRequestServices.AddnewRequest(RequestTitle, RequestContent, getCurrentUser, CategoryID, files, Priority, UserAssign, DepartmentAssign, UserFollow, isPrivate, IDTicket, TicketCustomerCode, TicketContractID);
            //        return RedirectToAction("Index", new RouteValueDictionary(
            //new { controller = "RequestList", action = "Index", notification = "NewRequest" }));
            //throw new AppException("Không tìm thấy tài khoản");
            return "OK";
        }
        public List<TicketCustomer> SearchCustomerTicket(string textString) {
            return _ticketServices.SearchUserFromTicket(textString);
        }
    }
}