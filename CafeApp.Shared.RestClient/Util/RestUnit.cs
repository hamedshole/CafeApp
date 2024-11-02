using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Common;
using CafeApp.Shared.RestClient.Interfaces;
using CafeApp.Shared.RestClient.Repositories;

namespace CafeApp.Shared.RestClient.Util
{
    internal class RestUnit : IRestUnit
    {
        private readonly HttpClient _httpClient;
        private ITableClient? _tablesClient;

        public RestUnit(ServerOptions serverOptions)
        {
            _httpClient = new HttpClient() { BaseAddress=new Uri( serverOptions.Url)};
        }

        public ITableClient Tables => _tablesClient ?? new TableClient(_httpClient, "tables");

        public IMaterialService Materials => throw new NotImplementedException();

        public IUnitService Units => throw new NotImplementedException();

        public IAdditiveService Additives => throw new NotImplementedException();

        public IProductCategoryService Categories => throw new NotImplementedException();

        public IProductService Products => throw new NotImplementedException();

        public IUserService Users => throw new NotImplementedException();

        public ICustomerService Customers => throw new NotImplementedException();

        public IOrderService Orders => throw new NotImplementedException();

        public IInventoryService Inventories => throw new NotImplementedException();

        public IFactorService Factors => throw new NotImplementedException();
    }
}
