using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.ViewModels.ListRequest;

namespace CSKH_SSP.Interfaces {
    public interface IRequestListServices {
        public (List<ListRequestTicket> ListRequestTickets, int TotalRequest, bool isLastItem) GetListRequest(int GroupUserID, string UserName, int? mention, string statusRequest, int pageNumber, string text, string category, string pri);
    }
}
