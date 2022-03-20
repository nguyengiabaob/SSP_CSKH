using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.AddNewRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.AddNewRequest
{
    public class AddNewRequestView
    {
        public List<Category> categories { get; set; }
        public List<Category> childCategories { get; set; }
        public List<Department> Departments { get; set; }
        public List<UserInDepartment> UserInDepartments { get; set; }
        public string CurrentEmail { get; set; }
        public string CurrentFullName { get; set; }
        public string UserName { get; set; }
        public string TicketId { get; set; }
    }
}
