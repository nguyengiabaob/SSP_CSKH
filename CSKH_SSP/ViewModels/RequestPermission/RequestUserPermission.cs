using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.RequestPermission
{
    public class RequestUserPermission
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string GroupID { get; set; }
        public string Avt { get; set; }
        public string note { get; set; }
    }
}
