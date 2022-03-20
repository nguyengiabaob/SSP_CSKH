using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.TicketArea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.ITicketServices
{
    public interface ITicketServices
    {
        public List<TicketCustomer> SearchUserFromTicket(string textString);
        public List<TicketContract> GetTicketContractInfo(string CustomerCode);
        public TicketCustomer GetTicketCustomersInfo(string CustomerID);
        public List<TicketContract> ContractsInfo(string ContractId);
        public MemberVNTT getMemberInfo(string customerId);
    }
}
