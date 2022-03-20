using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.ContentRequest
{
    public class ContentRequestBody
    {
        [Key]
        public int ID { get; set; }
        public string KeyReq { get; set; }
        public string UID { get; set; }
        public string IDEmail { get; set; }
        public string RequestTitle { get; set; }
        public string RequestContent { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorEmail { get; set; }
        public string CCEmail { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public string IsStaff { get; set; }
        public Nullable<bool> IsTimelinePoint { get; set; }
        public string UserName { get; set; }
        public string AvtUser { get; set; }
    }
}
