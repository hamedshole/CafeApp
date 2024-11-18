using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
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

                //_customers = await _unit.Customers.GetAll(CustomerSpecifications.FromParameter(parameter));
                if (_navigation.Uri.Contains("/tableOrder/", StringComparison.OrdinalIgnoreCase))
                {
                    DashboardTableModel table = await _unit.Tables.GetDashboardTable(Guid.Parse(Id));
                    if (table.State == TableState.filled)
                        _factor = table.Factor;
                    else
                        _factor = new DashboardFactorModel { TableId = table.Id, TableTitle = table.Title };
                }
                else
                {
                    _factor = _unit.Orders.GetBy(OrderSpecifications.GetOrder(Guid.Parse(Id)));
                }
                StateHasChanged();
            }
        }
        private List<CustomerDto> _customers = new List<CustomerDto>();
        private async Task<IEnumerable<Guid>> SearchCustomer(string text, CancellationToken cancellationToken = default)
        {
            ListCustomerParameter parameter = new ListCustomerParameter();

            _customers = await _unit.Customers.GetAll(CustomerSpecifications.FromParameter(parameter));
            return _customers.Select(x => x.Id).ToList();
        }

        //string GetCustomerName(Guid customerId)
        //{
        //    if (customerId == Guid.Empty)
        //        return string.Empty;
        //    else
        //        return _customers.FirstOrDefault(x => x.Id == customerId)!.FullName;
        //}
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
