using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Shared.RestClient.Interfaces
{
    public interface ITableClient
    {
        Task<ICollection<DashboardTableModel>> GetDashboardTables();

    }
}
