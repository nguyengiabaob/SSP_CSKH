using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels
{
    public class RequestContent
    {
        [Key]
        public int ID { get; set; }
        public string RequestID { get; set; }
        public string UID { get; set; }
        public string IDEmail { get; set; }
        public string TitleRequest { get; set; }
        public string ContentRequest { get; set; }
        public string UserName { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorEmail { get; set; }
        public string CCEmail { get; set; }
        public string Status { get; set; }
        public string IsStaff { get; set; }
        public Nullable<bool> IsTimelinePoint { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    }
}
