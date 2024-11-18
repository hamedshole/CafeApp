using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class CategoriesSection
    {
        [Parameter]
        public ICollection<DashboardFactorItemModel> FactorItems { get; set; }
        private List<DashboardCategoryModel> _categories;
        [Parameter]
        public Action<DashboardCategoryModel> ShowItemsMethod { get; set; }

        public CategoriesSection()
        {
            _categories = new List<DashboardCategoryModel>();
        }
        protected async override Task OnInitializedAsync()
        {
            _categories = (await _unit.Categories.GetForDashboard()).ToList();
            await SyncMenuItemsWithFactors();
        }
        public void ShowItems(DashboardCategoryModel category)
        {
            ShowItemsMethod.Invoke(category);
        }
        private async Task SyncMenuItemsWithFactors()
        {
            foreach (var item in FactorItems)
            {
                int _catIndex = _categories.IndexOf(_categories.FirstOrDefault(x => x.Id == item.CategoryId)!);
                var c = _categories[_catIndex];
                int _itemIndex = c.Items.IndexOf(c.Items.FirstOrDefault(x => x.Id == item.ProductId)!);
                _categories[_catIndex].Items[_itemIndex].Amount = item.TotalAmount;
            }
            if (FactorItems.Count > 0)
                _first = false;
            await Task.CompletedTask;
        }
        private bool _first = true;
        protected override async Task OnParametersSetAsync()
        {
            if (_first)
            {
                await SyncMenuItemsWithFactors();
            }
        }
    }
}
