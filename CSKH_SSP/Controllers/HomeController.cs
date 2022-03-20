using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using CSKH_SSP.DataModels;
using Microsoft.AspNetCore.Http;
using CSKH_SSP.Interfaces.IHelpersServices;

namespace CSKH_SSP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly IHelpersServices _helpersServices;

        public HomeController(IHelpersServices helpersServices)
        {
            _helpersServices = helpersServices;
        }

        public IActionResult Index(string RequestID, string TicketID, string activeStatus)
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

            ViewBag.gotoRequestID = string.IsNullOrEmpty(RequestID) ? "" : RequestID;
            ViewBag.Mynotification = string.IsNullOrEmpty(activeStatus) ? "" : activeStatus;
            ViewBag.addRequestFromTicket = "";

            if (!string.IsNullOrEmpty(TicketID))
            {
                if (_helpersServices.checkTicketIdIsAvailable(TicketID))
                {
                    ViewBag.addRequestFromTicket = TicketID;
                }
            }
            
            ViewBag.Username = getCurrentUser.UserName;
            ViewBag.UserID = getCurrentUser.UserID;
            ViewBag.GroupUserID = getCurrentUser.GroupUserID;
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}


    }
}
