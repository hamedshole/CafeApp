using AutoMapper;
using CafeApp.Business.Interfaces;
using CafeApp.Business.Services;
using CafeApp.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Business.Util
{
    internal class ApplicationUnit:IApplicationUnit
    {
        private readonly IDataUnit _dataUnit;
        private readonly IMapper _mapper;
        private readonly INotification _notification;
        private readonly TablesService? _tablesService;

        public ApplicationUnit(IDataUnit dataUnit, IMapper mapper)
        {
            _dataUnit = dataUnit;
            _mapper = mapper;
           
        }

        ITablesService IApplicationUnit.Tables => _tablesService??new TablesService(_dataUnit.Tables, _mapper);
    }
}
