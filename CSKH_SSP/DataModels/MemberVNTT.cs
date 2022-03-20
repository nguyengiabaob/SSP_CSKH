using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels
{
    public class MemberVNTT
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string AccountName { get; set; }

        [StringLength(150)]
        public string Password { get; set; }
        //public string PasswordHash { get; set; }



        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string IdCardTaxCode { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(150)]
        public string Wards { get; set; }

        [StringLength(150)]
        public string District { get; set; }

        [StringLength(150)]
        public string Province { get; set; }

        [StringLength(150)]
        public string Avatar { get; set; }


        public string OTP { get; set; }

        [StringLength(150)]
        public string DateCreateOTP { get; set; }

        public bool? Status { get; set; }

        public int? CustomerID { get; set; }

        public string CustomerCode { get; set; }
        public string AccountanceCode { get; set; }
    }
}
