using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.ContentRequest
{
    public class PrivateChat
    {
        public int ID { get; set; }
        public string RequestID { get; set; }
        public string TitleRequest { get; set; }
        public string ContentRequest { get; set; }
        public string AuthorFullName { get; set; }
        public string IsStaff { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    }
}
