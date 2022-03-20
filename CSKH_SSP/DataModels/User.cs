using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int GroupUserID { get; set; }
        public string Email { get; set; }
        public string PasswordEmail { get; set; }
        public Nullable<bool> IsStaff { get; set; }
        public Nullable<bool> IsChangePassOnTheFirst { get; set; }
        public string OTP { get; set; }
        public Nullable<System.DateTime> TimeCreateOTP { get; set; }
        public string Avt { get; set; }
        public int DepartmentID { get; set; }
        public Nullable<bool> IsOnline { get; set; }
        public Nullable<bool> IsReady { get; set; }
    }
}
