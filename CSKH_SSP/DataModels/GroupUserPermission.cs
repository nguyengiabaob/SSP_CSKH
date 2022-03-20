using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels {
    public class GroupUserPermission {
        [Key]
        public int GroupUserID { get; set; }
        public int IsEditRequest { get; set; }
        public int IsReceiveRequest { get; set; }
        public int IsRejectRequest { get; set; }
        public int IsAddUserAssign { get; set; }
        public int IsAddUserFollow { get; set; }
        public int IsAddDepartmentAssign { get; set; }
        public int IsReplyRequest { get; set; }
        public int IsFinishRequest { get; set; }
        public int IsDoneRequest { get; set; }
        public int IsUsePrivateChat { get; set; }
        public int IsRemoveAssign { get; set; }
    }
}
