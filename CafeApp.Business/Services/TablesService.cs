using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class TablesService : BaseService<TableEntity, TableDto>, ITablesService
    {
        public TablesService(IRepository<TableEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ICollection<DashboardTableModel>> GetDashboardTables()
        {
            ICollection<DashboardTableModel> tables = _repository.Get(x => x.IsActive)
                            .Select(x => new DashboardTableModel
                            {
                                Number = x.Number,
                                Id = x.Id,
                                Title = x.Title
                            }).ToList();
            foreach (var table in tables)
            {
                OrderEntity? order = _repository.DataUnit.Orders.Get(OrderSpecifications.GetTableState(table.Id)).FirstOrDefault();
                if (order is OrderEntity)
                {
                    table.State = TableState.filled;
                    table.LastState = TableState.filled;
                }
                else
                {
                    table.State = TableState.empty;
                    table.LastState = TableState.empty;
                }
            }
            return tables;
        }
        public async Task<DashboardTableModel> GetDashboardTable(Guid id)
        {
            DashboardTableModel table = _repository.Get(x => x.IsActive)
                            .Select(x => new DashboardTableModel
                            {
                                Number = x.Number,
                                Id = x.Id,
                                Title = x.Title
                            }).FirstOrDefault()!;

            OrderEntity? order = _repository.DataUnit.Orders.Get(OrderSpecifications.GetTableState(table.Id)).FirstOrDefault();
            if (order is OrderEntity)
            {
                table.State = TableState.filled;
                table.LastState = TableState.filled;
            }
            else
            {
                table.State = TableState.empty;
                table.LastState = TableState.empty;
            }

            return await Task.FromResult( table);
        }
    }
}
