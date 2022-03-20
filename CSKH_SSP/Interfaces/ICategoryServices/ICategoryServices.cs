using CSKH_SSP.DataModels;
using CSKH_SSP.Services.CategoryServices;

namespace CSKH_SSP.Interfaces.ICategoryServices
{
    public interface ICategoryServices
    {
        public CategoryDetail GetCategoryDetail(int Id);
        public string AddParentCategory(Category category);
        public string RemoveCategory(int Id);
    }
}
