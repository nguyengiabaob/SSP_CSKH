using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels {
    public class AttachFile {
        [Key]
        public int ID { get; set; }
        public string FileNameOriginal { get; set; }
        public string FileNameOnDB { get; set; }
        public Nullable<int> IDComment { get; set; }
        public string IDRequest { get; set; }
        public string OwerUserName { get; set; }
        public string Type { get; set; }
    }
}
