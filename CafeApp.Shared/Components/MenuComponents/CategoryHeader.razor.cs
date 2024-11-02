using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Shared.Components.MenuComponents
{
    public partial class CategoryHeader
    {
        private ICollection<MenuCategoryModel> _categories;
        public CategoryHeader()
        {
           _categories = new List<MenuCategoryModel>();
        }
        protected override async Task OnInitializedAsync()
        {
             _categories = await _unit.Categories.GetMenu();
        }
    }
}
