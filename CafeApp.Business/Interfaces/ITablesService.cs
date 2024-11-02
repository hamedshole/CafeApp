using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Interfaces
{
    public interface ITablesService:IBaseService<TableEntity,TableDto>
    {
        Task<ICollection<DashboardTableModel>> GetDashboardTables();
    }
}
