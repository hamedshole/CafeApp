using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class TableItem
    {
        [Parameter]
        public DashboardTableModel Item { get; set; }
        HubConnection connection;
        public TableItem()
        {

        }
        public async void Click()
        {
            if (Item.State == TableState.requesting && !string.IsNullOrEmpty(Item.LastConnectionId))
                await connection.InvokeAsync("ResponseTableAlert", Item.LastConnectionId);
            //if (Item.State == TableState.empty)
            //{
                Navigation.NavigateTo("/dashboard/tableOrder/" + Item.Id);
            //}
            //if (Item.State == TableState.filled && Item.Factor != null)
            //{
            //    Navigation.NavigateTo($"dashboard/order/{Item.Factor.Id}");

            //}
            Item.State = Item.LastState;
            StateHasChanged();
        }
        protected async override Task OnInitializedAsync()
        {
            connection = new HubConnectionBuilder().WithUrl($"{_server.Url}TableHub",
        opt =>
        {

        }).WithAutomaticReconnect().Build();

            await connection.StartAsync();
            await base.OnInitializedAsync();
        }
        void Test(string g)
        {

        }
    }
}
