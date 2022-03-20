using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.ListRequest {
    public class UserAssign {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool IsAssignOrFollow { get; set; }
        public string Status { get; set; }

    }
}
