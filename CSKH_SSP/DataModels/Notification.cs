using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels {
    public class Notification {
        [Key]
        public int notification_id { get; set; }
        public string type_id { get; set; }
        public string requestID { get; set; }
        public string UserName { get; set; }
       // public int DepartmentID { get; set; }
        private int myVar=0;

        public int DepartmentID
        {
            get { return myVar=0; }
            set { myVar = value; }
        }

        public string OwnerUserName { get; set; }
        public bool isSeen { get; set; }
        public bool isRead { get; set; }
        public DateTime Time { get; set; }
    }
}
