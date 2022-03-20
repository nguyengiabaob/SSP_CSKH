using CSKH_SSP.DataModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.IAddNewRequestServices
{
    public interface IAddNewRequestServices
    {
        public int AddnewRequest(string RequestTittle, string RequestContent, User UserInfomation, int CategoryID, List<IFormFile> files, int Priority, string[] UserAssign, int[] DepartmentAssign, string[] UserFollow,int isPrivate, string IDTicket, string TicketCustomerCode, string TicketContractID);
    }
}
