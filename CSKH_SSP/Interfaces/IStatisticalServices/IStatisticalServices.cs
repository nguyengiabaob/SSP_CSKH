using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.Statistical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.IStatisticalServices
{
    public interface IStatisticalServices
    {
        public List<Statistical> StatisticalRequest(DateTime? startDay, DateTime? endDate, DateTime? startDoneDay, DateTime? endDoneDate, string CustomerId, string TicketID, string ContractID, string UserAssign, string Category, string Status, bool IsPrivate);
    }
}
