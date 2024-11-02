using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class TablesPanel
    {
        HubConnection hubConnection;
        private IJSObjectReference? _module;
        public ICollection<DashboardTableModel> _tables { get; set; }
        public TablesPanel()
        {

            _tables = new List<DashboardTableModel>();


        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                _module = await _js.InvokeAsync<IJSObjectReference>("import", "/_content/CafeApp.Shared/scripts/TablesPanel.js");
        }
        protected async override Task OnInitializedAsync()
        {

            hubConnection = new HubConnectionBuilder()
         .WithUrl($"{_server.Url}TableHub")
         .Build();
            hubConnection.On<string, string>("TableAlert", Alert);
            await hubConnection.StartAsync();

            _tables = await _unit.Tables.GetDashboardTables();
        }
        private async void Alert(string tableId, string connectionId)
        {
            _tables.FirstOrDefault(x => x.Number == int.Parse(tableId))!.LastState = _tables.FirstOrDefault(x => x.Number == int.Parse(tableId))!.State;

            _tables.FirstOrDefault(x => x.Number == int.Parse(tableId))!.State = TableState.requesting;
            _tables.FirstOrDefault(x => x.Number == int.Parse(tableId))!.LastConnectionId = connectionId;
            if (_module != null)
            {
                await _module!.InvokeVoidAsync("PlayAlert");
            }
                await InvokeAsync(StateHasChanged);
        }
    }
}
