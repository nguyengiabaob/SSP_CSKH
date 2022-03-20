using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels {
    public class EmailConfig {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEnable { get; set; }
    }
}
