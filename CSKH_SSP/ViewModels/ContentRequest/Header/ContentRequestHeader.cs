using CSKH_SSP.ViewModels.ContentRequest.Header;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.ContentRequest {
    public class ContentRequestHeader {
        [Key]
        public string RequestID { get; set; }
        public string RequestStatus { get; set; }
        public string RequestTittle { get; set; }
        public string RequestAuthor { get; set; }
        public DateTime? RequestDay { get; set; }
        public string RequestCategory { get; set; }
        public int CategoryID { get; set; }
        public DateTime? FinishDay { get; set; }
        public Nullable<bool> attFile { get; set; }
        public DateTime? TimeDone { get; set; }
        public int RequestPriority { get; set; }
        public string ListCCMail { get; set; }
        public string ListMailTo { get; set; }
        public string RequestNotes { get; set; }
        public string Feedback { get; set; }
        public Nullable<int> Rating { get; set; }
        public string createByUserName { get; set; }
        public bool isCreateRequest { get; set; }
        public bool isAssignRequest { get; set; }
        public bool isAdmin { get; set; }
        public bool IsPinned { get; set; }
        public bool? IsQuestion { get; set; }
    }
}
