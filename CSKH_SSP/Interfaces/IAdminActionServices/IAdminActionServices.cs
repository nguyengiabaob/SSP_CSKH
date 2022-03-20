using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.IAdminActionServices
{
    public interface IAdminActionServices
    {
        public string DisableCategory(string status);
        public string AddCategory(string CategoryName);
        public string SetPermission(string[] Username, int GroupUserID);
        public string DeletePermission(string Username);
        public string AddUserToCategory(string[] Username, int CategoryId);
        public string DeleteUserFromCategory(string Username, int CategoryId);
        public string SetHoursDeadline(int hours, int hourResolve, int CategoryId);
    }
}
