using CafeApp.Business.Helpers.Dtos;
using CafeApp.Shared.RestClient.Interfaces;
using System.Net.Http.Json;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class TableClient : ITableClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _api;

        public TableClient(HttpClient httpClient, string api)
        {
            _httpClient = httpClient;
            _api = api;
        }

        public async Task<ICollection<DashboardTableModel>> GetDashboardTables()
        {
          var res=await  _httpClient.GetFromJsonAsync<ICollection<DashboardTableModel>>($"api/{_api}/dashboardtables");
            return res!;
        }
    }
}
