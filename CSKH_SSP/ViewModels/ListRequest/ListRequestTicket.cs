using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.ContentRequest.Header;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.ListRequest {
    public class ListRequestTicket {
        [Key]
        public string RequestID { get; set; }
        public string RequestStatus { get; set; }
        public string RequestTittle { get; set; }
        public string RequestAuthor { get; set; }
        public DateTime? RequestDay { get; set; }
        public string RequestCategory { get; set; }
        public int CategoryID { get; set; }
        public DateTime? ReceiverTime { get; set; }
        public DateTime? FinishDay { get; set; }
        public int UserIDPermission { get; set; }
        public string isDeadLine { get; set; }
        public string daysRemain { get; set; }
        public int RequestPriority { get; set; }
        public IEnumerable<User> UserAssign { get; set; }
        public IEnumerable<User> UserFollow { get; set; }
        public IEnumerable<Department> DepartmentAssign { get; set; }
        public int CountNewMess { get; set; }
        public bool isReadOnChange { get; set; }
        //public int CountPrivateMess { get; set; }
        public Nullable<bool> attFile { get; set; }
        public DateTime? TimeDone { get; set; }
    }
}
