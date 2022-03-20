using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels {
    public class Requestinfo {
        [Key]
        public int ID { get; set; }
        public string RequestID { get; set; }
        public string RequestAuthorFullName { get; set; }
        public string RequestAuthorUserName { get; set; }
        public string RequestAuthorEmail { get; set; }
        public string RequestTittle { get; set; }
        public DateTime RequestDay { get; set; }
        public string RequestContent { get; set; }
        public string RequestStatus { get; set; }
        public string LastUpdatedBy { get; set; }
        public string RequestPostPassword { get; set; }
        public Nullable<System.DateTime> ReceiverTime { get; set; }
        public Nullable<int> RequestCommentCount { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public Nullable<bool> IsFinish { get; set; }
        public string FinishBy { get; set; }
        public string RequestNotes { get; set; }
        public string CancelBy { get; set; }
        public Nullable<System.DateTime> CancelTime { get; set; }
        public Nullable<bool> IsCancel { get; set; }
        public string LastAdviceBy { get; set; }
        public string createByUserName { get; set; }
        public Nullable<int> Category { get; set; }
        public Nullable<bool> isSupportByEmail { get; set; }
        public string listCCMail { get; set; }
        public string listMailTo { get; set; }
        public Nullable<System.DateTime> TimeDone { get; set; }
        public Nullable<System.DateTime> TimeTemporaryDone { get; set; }
        public Nullable<int> Priority { get; set; }
        public string Feedback { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<bool> hasAttFile { get; set; }
        public Nullable<bool> IsFromEmail { get; set; }
        public Nullable<int> ReasonID { get; set; }
        public string ReasonNote { get; set; }
        public Nullable<System.DateTime> FinishTime { get; set; }
        public string TicketID { get; set; }
        public string TicketCustomerID { get; set; }
        public string ContractID { get; set; }
        public Nullable<bool> IsPrivate { get; set; }
        public Nullable<bool> IsSeenWhenDone { get; set; }
        public Nullable<bool> IsQuestion { get; set; }

    }
}
