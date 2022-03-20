using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.UserInfomation
{
    public class WhoIsOnline
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int GroupUserID { get; set; }
        public bool isOnline { get; set; }
        public bool isReady { get; set; }
        public int countFinishTask { get; set; }
        public int countAllTask { get; set; }
    }
}
