using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces.ITicketServices;
using CSKH_SSP.ViewModels.TicketArea;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSKH_SSP.Controllers.TicketArea
{
    //[Authorize]
    public class TicketAreaController : Controller
    {
        private readonly ITicketServices _ticketServices;

        public TicketAreaController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        public IActionResult _TicketArea(string textString)
        {
            var a = _ticketServices.SearchUserFromTicket(textString);
            return View(a);
        }



        public MemberVNTT getMemberInfo(string CustomerId)
        {
            return _ticketServices.getMemberInfo(CustomerId);
        }

        public IActionResult SearchCustomerTicket(string textString)
        {
            if (string.IsNullOrEmpty(textString))
            {
                return null;
            }
            else
            {
                var res = _ticketServices.SearchUserFromTicket(textString);
                return View(res);
            }
        }

        public IActionResult GetTicketContractInfo(string CustomerCode)
        {
            return View(_ticketServices.GetTicketContractInfo(CustomerCode));
        }

        public TicketCustomer TicketCustomersInfo(string CustomerCode)
        {
            return _ticketServices.GetTicketCustomersInfo(CustomerCode);
        }

        public List<TicketContract> TicketContracts(string ContractId)
        {
            return _ticketServices.ContractsInfo(ContractId);
        }


    }
}
