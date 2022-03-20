using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces.IAdminServices;
using CSKH_SSP.Interfaces.ICountUserOnlineService;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.ViewModels.UserInfomation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CSKH_SSP.Controllers.AdminArea
{
    public class StatisticController : Controller
    {
        private readonly IStatisticServices _iStatisticServices;



        private readonly ICountUserOnlineService _iCountUserOnlineService;
        private readonly IHelpersServices _helpersServices;


        public StatisticController(ICountUserOnlineService iCountUserOnlineService, IHelpersServices helpersServices, IStatisticServices iStatisticServices)
        {
            _iCountUserOnlineService = iCountUserOnlineService;
            _helpersServices = helpersServices; 
            _iStatisticServices = iStatisticServices;
        }
        // List<WhoIsOnline> 
        public IActionResult Index()
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

            return View(_iCountUserOnlineService.UpdateWhoIsOnline(getCurrentUser.UserID, true).OrderByDescending(x => x.isOnline).ThenBy(x => x.isReady).ToList());
        }
        public IActionResult taskOfUserId(int UserId)
        {
            return View(_iStatisticServices.ListRequestOfUser(UserId));
        }
    }
}
