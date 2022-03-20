using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels {
    public class CountNewMessageForUser {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string RequestID { get; set; }
        public int CountMess { get; set; }
        public string Status { get; set; }
    }
}
