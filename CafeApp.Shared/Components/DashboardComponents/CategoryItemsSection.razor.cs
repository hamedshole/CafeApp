using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class CategoryItemsSection
    {
        private IJSObjectReference? _module;

        

        [Parameter]
        public EventCallback<DashboardProductModel> AddFactorItem { get; set; }

        [Parameter]
        public EventCallback<DashboardProductModel> MinusFactorItem { get; set; }

        [Parameter]
        public DashboardCategoryModel Category { get; set; }

        public CategoryItemsSection()
        {
            if (Category is null)
                Category = new DashboardCategoryModel();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _module = await _js.InvokeAsync<IJSObjectReference>("import", "/_content/CafeApp.Shared/scripts/CategoryItemsSection.js");
            }
        }
        public void Update() => StateHasChanged();
        public void Add(DashboardProductModel dashboardProduct)
        {
            dashboardProduct.Amount++;
            _module.InvokeVoidAsync("Add", $"item-{dashboardProduct.Id}");
            AddFactorItem.InvokeAsync(dashboardProduct);
        }
        public void Minus(DashboardProductModel dashboardProduct)
        {
            if (dashboardProduct.Amount > 0)
            {
                dashboardProduct.Amount--;
                _module.InvokeVoidAsync("Minus", $"item-{dashboardProduct.Id}");
                MinusFactorItem.InvokeAsync(dashboardProduct);
            }

        }
        private string GetItemDisplay(int amount)
        {
            if (amount == 0)
                return "none";
            else
                return "inline";
        }

    }
}
