using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces.ICategoryServices;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CSKH_SSP.Controllers.Categories
{
    public class CategoriesController : Controller
    {

        private readonly IHelpersServices _helpersServices;
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(IHelpersServices helpersServices, ICategoryServices categoryServices)
        {
            _helpersServices = helpersServices;
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            var categories = _helpersServices.GetAllCategories();   
            return View(categories.ToList());
        }

        public IActionResult CategoryDetails(int Id)
        {
            var categoryDetail = _categoryServices.GetCategoryDetail(Id);
            return View(categoryDetail);
        }

        public string AddParentCategory(Category category)
        {
            return _categoryServices.AddParentCategory(category);
        }

        public string RemoveCategory(int Id)
        {
            return _categoryServices.RemoveCategory(Id);
        }


    }
}
