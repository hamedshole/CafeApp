using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class FactorItem
    {
        [Parameter]
        public DashboardFactorItemModel Item { get; set; }
        public FactorItem()
        {
            Item = new DashboardFactorItemModel();
        }

        public void Add()
        {
            if (Item.PaidAmount < Item.TotalAmount)
                Item.PaidAmount++;
        }
        public void Minus()
        {
            if (Item.PaidAmount > Item.SubmittedDongi)
                Item.PaidAmount--;
        }
        public void SubmitDongi() => Item.SubmittedDongi = Item.PaidAmount;
    }
}
