using CSKH_SSP.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.IAdminServices
{
   public interface IUserManagementServices
    {
        public string AddNewUser(User user);
    }
}
