using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.ContentRequest.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.ListRequest {
    public class ListRequestAndPermission {
        public List<ListRequestTicket> ListRequest { get; set; }
        public GroupUserPermission GroupUserPermission { get; set; }
        public RenderButton RenderButton { get; set; }
        public int MinPage { get; set; }
        public int MaxPage { get; set; }
        public int TotalItem { get; set; }
        public bool IsLastItem { get; set; }
    }
}
