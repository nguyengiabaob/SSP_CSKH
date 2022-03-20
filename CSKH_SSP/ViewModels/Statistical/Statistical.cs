using CSKH_SSP.DataModels;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.Statistical
{
    public class Statistical : Requestinfo
    {
        public string AssignBy { get; set; }
        public string AssignLv2 { get; set; }
        public string AssignLv3 { get; set; }

        public string CategoryName { get; set; }
        public string ngayHoanTat { get; set; }
        public string RequestComment { get; set; }
        public bool? SLAResponse { get; set; }   
        public bool? SLAResolve { get; set; }   
    }
}
