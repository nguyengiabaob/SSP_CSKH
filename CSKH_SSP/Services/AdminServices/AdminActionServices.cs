using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IAdminActionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Services.AdminServices
{
    public class AdminActionServices : IAdminActionServices
    {
        private DataContext _context;

        public AdminActionServices(DataContext context)
        {
            _context = context;
        }

        public string AddCategory(string CategoryName)
        {
            var temp = _context.Category.Where(x => x.CategoryName == CategoryName).FirstOrDefault();
            if (temp == null)
            {
                var categoryObj = new Category();
                categoryObj.CategoryName = CategoryName;
                _context.Category.Add(categoryObj);
                _context.SaveChanges();
                return "1";
            }
            else
            {
                return "2";
            }
        }

        public string SetPermission(string[] Username, int GroupUserID)
        {
            if (Username != null || Username.Length > 0)
            {
                foreach (var item in Username)
                {
                    var a = _context.User.Where(x => x.UserName == item).FirstOrDefault();
                    if (a != null)
                    {
                        a.GroupUserID = GroupUserID;
                    }
                }
                _context.SaveChanges();
                return "1";
            }
            else
            {
                return "0";
            }
        }


        public string AddUserToCategory(string[] Username, int CategoryId)
        {
            if (Username != null || Username.Length > 0)
            {
                foreach (var item in Username)
                {
                    CategoryPermission categoryPermission = new CategoryPermission()
                    {
                        IDCategory = CategoryId,
                        UserName = item
                    };
                    _context.CategoryPermission.Add(categoryPermission);
                }
                _context.SaveChanges();
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public string SetHoursDeadline(int hours, int hourResolve, int CategoryId)
        {
            var a = _context.Category.Where(x => x.IDCategory == CategoryId && x.isActive != false).FirstOrDefault();
            a.HoursDeadline = hours;
            a.HoursResolve = hourResolve;
            _context.SaveChanges();
            return "1";
        }

        public string DeleteUserFromCategory(string Username, int CategoryId)
        {
            var a = _context.CategoryPermission.Where(x => x.UserName == Username && x.IDCategory == CategoryId).FirstOrDefault();
            _context.CategoryPermission.Remove(a);
            _context.SaveChanges();
            return "1";

        }

        public string DeletePermission(string Username)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                var a = _context.User.Where(x => x.UserName == Username).FirstOrDefault();
                if (a != null)
                {
                    a.GroupUserID = 3;
                }

                _context.SaveChanges();
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public string SetDepartmentPermission(int DepartmentID, int GroupUserID)
        {
            //var tempUser = _context.User.Where(x => x.UserName == Username).FirstOrDefault();
            var userInDepartment = _context.User.Where(x => x.DepartmentID == DepartmentID);



            if (userInDepartment != null)
            {
                foreach (var i in userInDepartment)
                {
                    i.GroupUserID = GroupUserID;
                    _context.SaveChanges();
                }
                return "1";
            }
            else
            {
                return "0";
            }
        }


        public string DisableCategory(string status)
        {
            if (!string.IsNullOrEmpty(status))
            {
                var a = status.Split("--");
                var temp = _context.Category.Where(x => x.IDCategory.ToString() == a[0]).FirstOrDefault();
                if (temp != null)
                {
                    if (a[1] == "true")
                    {
                        temp.isActive = true;
                    }
                    else
                    {
                        temp.isActive = false;
                    }
                    _context.SaveChanges();
                    return "1";
                }
                else
                {
                    return "404";
                }
            }
            else { return "404"; }
        }
    }
}
