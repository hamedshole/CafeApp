using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Shared.Components.MenuComponents
{
    public partial class CategorySection
    {
        ICollection<MenuCategoryModel> _categories;
        public CategorySection()
        {
            _categories = new List<MenuCategoryModel>();
        }
    }
}
