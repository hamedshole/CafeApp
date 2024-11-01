using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
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
    }
}
