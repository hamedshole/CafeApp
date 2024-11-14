﻿using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class Factor
    {
       
        [Parameter]
        public DashboardFactorModel Item { get; set; } = new DashboardFactorModel();

        private IJSObjectReference _module;
        private bool _dongi = false;
        public Factor()
        {
            Item = new DashboardFactorModel();
        }
        public void Add(DashboardProductModel dashboardProduct)
        {
            DashboardFactorItemModel item = Item.Items.FirstOrDefault(x => x.Id == dashboardProduct.Id);
            if (item == null)
            {
                item = new DashboardFactorItemModel() { Id = dashboardProduct.Id, ProductTitle = dashboardProduct.Title, TotalAmount = dashboardProduct.Amount, UnitPrice = dashboardProduct.Price };
                Item.Items.Add(item);
            }
            else
                item.TotalAmount = item.TotalAmount + 1;

            StateHasChanged();
        }
        public void Minus(DashboardProductModel dashboardProduct)
        {
            DashboardFactorItemModel item = Item.Items.FirstOrDefault(x => x.Id == dashboardProduct.Id);
            if (item != null)
            {
                if (item.TotalAmount == 1)
                    Item.Items.Remove(item);
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
           await _module.InvokeVoidAsync("enableDongi",_dongi);
            if (_dongi)
            {
                foreach (var item in Item.Items)
                    item.SubmitDongi();
                StateHasChanged();
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
        private CustomerDto _selectedCustomer=new CustomerDto();
        private async Task<IEnumerable<CustomerDto>> SearchCustomer(string text,CancellationToken cancellationToken = default)
        {
            ListCustomerParameter parameter = new ListCustomerParameter();

           return await _unit.Customers.GetAll(CustomerSpecifications.FromParameter(parameter));
        }
        

    }
}
