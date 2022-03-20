using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Interfaces.ICountRequest;
using Microsoft.AspNetCore.Mvc;

namespace CSKH_SSP.Controllers
{
    public class MyNotification : Controller
    {
        private readonly ICountRequestServices _countRequestServices;
        public MyNotification(ICountRequestServices countRequestServices)
        {
            _countRequestServices = countRequestServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public string getNotification(string Username)
        {
            var count = _countRequestServices.CountNotificationOfUser(Username);
            return count;
        }
    }
}
