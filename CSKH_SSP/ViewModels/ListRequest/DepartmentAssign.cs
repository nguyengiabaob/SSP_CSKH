using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.ListRequest {
    public class DepartmentAssign {
        public int DepartmentID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public bool IsAssignOrFollow { get; set; }
        public string isHasEmail { get; set; }

    }
}
