using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels
{
    public class Advice
    {
        [Key]
        public int IDAdvice { get; set; }
        public string RequestID { get; set; }
        public string FromUserName { get; set; }
        public string ToUserUserName { get; set; }
        public int CommentID { get; set; }
    }
}
