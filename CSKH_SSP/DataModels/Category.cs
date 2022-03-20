using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels {
    public class Category {
        [Key]
        public int IDCategory { get; set; }
        public int? ParentId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public int? HoursDeadline { get; set; }
        public int? HoursResolve { get; set; }
    }
}
