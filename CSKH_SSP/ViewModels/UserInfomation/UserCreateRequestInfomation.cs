using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.UserInfomation {
    public class UserCreateRequestInfomation {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public int TotalRequest { get; set; }
    }
}
