using CafeApp.Business.Helpers.Dtos;
using CafeApp.Shared.Components.DashboardComponents;
using Microsoft.AspNetCore.Components;
using System.Numerics;

namespace CafeApp.Shared.Pages.Ordering
{
    public partial class OrderingFactor
    {

        [CascadingParameter]
        public TablesPanel TablesPanel { get; set; }
        List<DashboardTableModel> _tables = new List<DashboardTableModel>();
        DashboardTableModel _selectedTable = new DashboardTableModel();

        private CategoryItemsSection _selectedCategory;
        private Factor _factorPanel;
        private Guid _prevId = Guid.Empty;
        private CategoriesSection _categoriesSection;
        private List<DashboardCategoryModel> defaultCategories;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (_navigation.Uri.Contains("dashboard/tableOrder/"))
                await FromTableRoute(firstRender, null);

        }

        private async Task LoadOrder()
        {
            var order = await _unit.Orders.GetById(Guid.Parse(OrderId));
            TableId = order.TableId.ToString();
            await FromTableRoute(false, order);
        }

        private async Task FromTableRoute(bool firstRender, DashboardFactorModel? factor)
        {
            if (firstRender || Guid.Parse(TableId) != _prevId)
            {
                if (defaultCategories is null)
                    defaultCategories = (await _unit.Categories.GetForDashboard()).ToList();

                if (_tables.Count == 0)
                {
                    foreach (var table in TablesPanel._tables)
                    {
                        table.Categories = DeepCopyCategories(defaultCategories);
                        _tables.Add(table);
                    }
                }

                _selectedTable = _tables.FirstOrDefault(x => x.Id == Guid.Parse(TableId));
                if (factor is DashboardFactorModel && _selectedTable.Factor is null)
                    _selectedTable!.Factor = factor;
                if (_selectedTable!.Factor is null)
                    _selectedTable!.Factor = new DashboardFactorModel() { TableId = _selectedTable.Id, TableTitle = _selectedTable.Title };
                foreach (var item in _selectedTable.Factor.Items)
                {
                    int _catIndex = _selectedTable.Categories!.IndexOf(_selectedTable.Categories.FirstOrDefault(x => x.Id == item.CategoryId)!);
                    var c = _selectedTable.Categories[_catIndex];
                    int _itemIndex = c.Items.IndexOf(c.Items.FirstOrDefault(x => x.Id == item.ProductId)!);
                    _selectedTable.Categories[_catIndex].Items[_itemIndex].Amount = item.TotalAmount;

                    InvokeAsync(_categoriesSection.Reload);
                }
                _prevId = Guid.Parse(TableId);
                StateHasChanged();
            }
        }

        public void ShowItems(DashboardCategoryModel category)
        {
            _selectedTable.SelectedCategory = category;

            _selectedCategory.Update();
        }
        public void AddItem(DashboardProductModel dashboardProduct)
        {
            if (_selectedTable.Factor is null)
                _selectedTable.Factor = new DashboardFactorModel();
            _factorPanel.Add(dashboardProduct);
        }
        public void MinusItem(DashboardProductModel dashboardProduct)
        {
            _factorPanel.Minus(dashboardProduct);
        }
        public List<DashboardCategoryModel> DeepCopyCategories(List<DashboardCategoryModel> categories)
        {
            return categories.Select(category => new DashboardCategoryModel
            {
                Id = category.Id,
                Title = category.Title,
                Items = category.Items.Select(item => new DashboardProductModel
                {
                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    Title = item.Title,
                    Amount = item.Amount,
                    Price = item.Price
                }).ToList()
            }).ToList();
        }
    }
}
