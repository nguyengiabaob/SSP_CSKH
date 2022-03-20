using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.ICategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSKH_SSP.Services.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private DataContext _context;

        public CategoryServices(DataContext context)
        {
            _context = context;
        }

        public string priorityText()
        {
            var res = "";
            var a = _context.Priority.ToList();
            res += a[0].PriorityName + " : " + a[0].Hours + " giờ ," + a[1].PriorityName + " : " + a[1].Hours + " giờ ," + a[2].PriorityName + " : " + a[2].Hours + " giờ ," + a[3].PriorityName + " : " + a[3].Hours + " giờ ,";
            return res;
        }



        public CategoryDetail GetCategoryDetail(int Id)
        {
            var res = new CategoryDetail();
            res.category = _context.Category.Where(x => x.IDCategory == Id && x.isActive != false).FirstOrDefault();
            var parent = _context.Category.Where(x => x.IDCategory == res.category.ParentId && x.isActive != false).FirstOrDefault();
            string txt = "";
            var a = _context.Priority.ToList();
            txt += a[0].PriorityName + " : " + a[0].Hours + " giờ ," + a[1].PriorityName + " : " + a[1].Hours + " giờ ," + a[2].PriorityName + " : " + a[2].Hours + " giờ ," + a[3].PriorityName + " : " + a[3].Hours + " giờ ,";
            res.priorityText = txt;
            res.categoryPermission = _context.CategoryPermission.Where(x => x.IDCategory == Id).ToList();
            
            return res;
        }

        public string AddParentCategory(Category category)
        {
            try
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                return "0";
            }

        }

        public string RemoveCategory(int Id)
        {
            try
            {
                var a = _context.Category.Where(x => x.IDCategory == Id).FirstOrDefault();
                a.isActive = false;
                _context.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                return "0";
            }

        }


    }

    public class CategoryDetail : Category
    {
        public Category category { get; set; }
        public List<CategoryPermission> categoryPermission { get; set; }
        public string priorityText { get; set; }
    }
}
