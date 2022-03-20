using CSKH_SSP.ViewModels.ListRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.IAdminServices
{
    public interface IStatisticServices
    {
        public int countProcessingTaskOfUser(int UserID);
        public List<ListRequestTicket> ListRequestOfUser(int UserID);
    }
}
