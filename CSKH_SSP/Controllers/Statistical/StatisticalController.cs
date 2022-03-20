using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Interfaces.IStatisticalServices;
using Microsoft.AspNetCore.Mvc;

namespace CSKH_SSP.Controllers.Statistical
{
    public class StatisticalController : Controller
    {
        private readonly IStatisticalServices _statisticalServices;

        public StatisticalController(IStatisticalServices statisticalServices)
        {
            _statisticalServices = statisticalServices;
        }

        public IActionResult Index(DateTime? startDay, DateTime? endDate, DateTime? startDoneDay, DateTime? endDoneDate, string CustomerId, string TicketID, string ContractID, string UserAssign, string Category, string Status, bool IsPrivate)
        {
            var a = _statisticalServices.StatisticalRequest(startDay, endDate, startDoneDay, endDoneDate, CustomerId, TicketID, ContractID, UserAssign, Category, Status, IsPrivate);
            return View(a);
        }
    }
}
