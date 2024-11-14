using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class CategoriesSection
    {
        private ICollection<DashboardCategoryModel> _categories;
        [Parameter]
        public Action<DashboardCategoryModel> ShowItemsMethod { get; set; }

        public CategoriesSection()
        {
            _categories = new List<DashboardCategoryModel>();
        }
        protected async override Task OnInitializedAsync()
        {
            _categories = await _unit.Categories.GetForDashboard();
        }
        public void ShowItems(DashboardCategoryModel category)
        {
            ShowItemsMethod.Invoke(category);
        }
    }
}
