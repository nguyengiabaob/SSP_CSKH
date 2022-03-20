using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels
{
    public class RequestPinned
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string RequestID { get; set; }

    }
}
