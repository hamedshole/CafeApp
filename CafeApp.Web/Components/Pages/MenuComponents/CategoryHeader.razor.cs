using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Web.Components.Pages.MenuComponents
{
    public partial class CategoryHeader
    {
        private ICollection<ProductCategoryModel> _categories;
        public CategoryHeader()
        {
            _categories = new List<ProductCategoryModel>
            {
                new ProductCategoryModel{Id=Guid.NewGuid(),Title="1"},
                new ProductCategoryModel{Id=Guid.NewGuid(),Title="2"},
                new ProductCategoryModel{Id=Guid.NewGuid(),Title="3"},
                new ProductCategoryModel{Id=Guid.NewGuid(),Title="4"},
            };
        }
    }
}
