using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.TicketArea
{
    public class TicketContract
    {
        public string ContractCode { get; set; }
        public string ContractFast { get; set; } // Ma hop dong ban'
        public string ContractName { get; set; }
        public string Department { get; set; }
    }
}
