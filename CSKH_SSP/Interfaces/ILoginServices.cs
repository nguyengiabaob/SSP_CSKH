using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;

namespace CSKH_SSP.Interfaces
{
    public interface ILoginServices
    {
        User Authorize(string UserName, string Password);
        User SSPLogin(string user, string Key);
    }
}
