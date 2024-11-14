using CafeApp.Business.Helpers.Dtos;
using CafeApp.Shared.Components.DashboardComponents;

namespace CafeApp.Shared.Pages.Ordering
{
    public partial class OrderingFactor
    {
        private CategoryItemsSection _selectedCategory;
        DashboardFactorModel _factor = new DashboardFactorModel();
        private Factor _factorPanel;

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
            DashboardTableModel table = await _unit.Tables.GetDashboardTable(Guid.Parse( Id));
            if (table.State == TableState.empty)
                _factor = new DashboardFactorModel { TableId = table.Id, TableTitle = table.Title };
            StateHasChanged();
            }
        }
        public void ShowItems(DashboardCategoryModel category)
        {
            _selectedCategory.Category = category;
            _selectedCategory.Update();
        }
        public void AddItem(DashboardProductModel dashboardProduct)
        {
            if (_factorPanel is null)
                _factor = new DashboardFactorModel();
            _factorPanel.Add(dashboardProduct);
        }
        public void MinusItem(DashboardProductModel dashboardProduct)
        {
            _factorPanel.Minus(dashboardProduct);
        }
    }
}
