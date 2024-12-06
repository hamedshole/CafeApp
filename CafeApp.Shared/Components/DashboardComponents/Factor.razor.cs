using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class Factor
    {
        [Parameter]
        public EventCallback Pay { get; set; }

        private long _livePaidAmount = 0;

        [Parameter]
        public DashboardTableModel Table { get; set; } = new DashboardTableModel();

        public long LivePaidAmount { get; set; }

        private IJSObjectReference _module;
        private bool _dongi = false;
        public Factor()
        {
            Table = new DashboardTableModel();
        }
        public void SetCustomer(CustomerDto value)
        {
            Table.Factor.CustomerId = value.Id;
        }
        public void Add(DashboardProductModel dashboardProduct)
        {
            DashboardFactorItemModel item = Table.Factor.Items.FirstOrDefault(x => x.ProductId == dashboardProduct.Id);
            if (item == null)
            {
                item = new DashboardFactorItemModel() { ProductId = dashboardProduct.Id, CategoryId = dashboardProduct.CategoryId, ProductTitle = dashboardProduct.Title, TotalAmount = dashboardProduct.Amount, UnitPrice = dashboardProduct.Price };
                Table.Factor.Items.Add(item);
            }
            else
                item.TotalAmount = item.TotalAmount + 1;

            StateHasChanged();
        }
        public void Minus(DashboardProductModel dashboardProduct)
        {
            DashboardFactorItemModel item = Table.Factor.Items.FirstOrDefault(x => x.Id == dashboardProduct.Id);
            if (item != null)
            {
                if (item.TotalAmount == 1)
                    Table.Factor.Items.Remove(item);
                else
                {
                    if (item.TotalAmount != 0)
                        item.TotalAmount--;

                }
            }
            StateHasChanged();
        }
        public async void EnableDongi()
        {
            await _module.InvokeVoidAsync("enableDongi", _dongi);
            if (_dongi)
            {
                foreach (var item in Table.Factor.Items)
                {
                    item.SubmitDongi();
                    await _unit.Orders.PayOrderItem(Table.Factor.Id, item.Id, item.PaidAmount);
                }
                Table.Factor.Paid = Table.Factor.Paid + _livePaidAmount;
                _livePaidAmount = 0;
                StateHasChanged();
                await _unit.Orders.PayOrder(Table.Factor.Id,Table.Factor.Paid);
                
            }
            _dongi = !_dongi;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _module = await _js.InvokeAsync<IJSObjectReference>("import", "/_content/CafeApp.Shared/scripts/Item.js");
            }
        }
        //private CustomerDto _selectedCustomer=new CustomerDto();
        //private async Task<IEnumerable<CustomerDto>> SearchCustomer(string text,CancellationToken cancellationToken = default)
        //{
        //    ListCustomerParameter parameter = new ListCustomerParameter();

        //   return await _unit.Customers.GetAll(CustomerSpecifications.FromParameter(parameter));
        //}

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                //_selectedCustomer=await _unit.Customers.GetById(Item.CustomerId);
            }
        }
        public void AddPrice(long unitPrice)
        {
            _livePaidAmount += unitPrice;
            InvokeAsync(StateHasChanged);

        }
        public void MinusPrice(long unitPrice)
        {
            _livePaidAmount -= unitPrice;
            InvokeAsync(StateHasChanged);
        }

        public async Task ApplyDeliver(DashboardFactorItemModel item)
        {
            if (Table.Factor.Id != Guid.Empty)
                await _unit.Orders.ApplyDeliver(item, Table.Factor.Id);
        }
        public async Task UpdateOrder()
        {
            try
            {
                CreateOrderParameter orderParameter = new CreateOrderParameter
                {
                    Id = Table.Factor.Id,
                    Description = Table.Factor.Description,
                    Type =(FactorType)Table.Factor.Type,
                    Time =Table.Factor.Time,
                    State =(FactorState) Table.Factor.State,
                    UserId = Table.Factor.UserId,
                    TableId = Table.Factor.TableId,
                    Items = Table.Factor.Items.Select(x => new CreateOrderItemParameter
                    {
                        Id = x.Id,
                        HasAdditive = false,
                        ProductId = x.ProductId,
                        TotalPrice = x.TotalPrice,
                        Amount = x.TotalAmount,
                        Additives = null
                    }).ToList()
                };
                if (Table.Factor.CustomerId == Guid.Empty)
                    orderParameter.CustomerId = null;
                await _unit.Orders.DeleteAsync(Table.Factor.Id,false);
                await _unit.Orders.CreateAsync(orderParameter);

            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task DeleteOrder()
        {
            await _unit.Orders.DeleteAsync(Table.Factor.Id);
        }
    }
}
