using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;

namespace CafeApp.Shared.RestClient.Interfaces
{
    public interface IRestUnit
    {
        ITableClient Tables { get; }
        IMaterialService Materials { get; }
        IUnitService Units { get; }
        IAdditiveService Additives { get; }
        IProductCategoryService Categories { get; }
        IProductService Products { get; }
        IUserService Users { get; }
        ICustomerService Customers { get; }
        IOrderService Orders { get; }
        IInventoryService Inventories { get; }
        IFactorService Factors { get; }
    }
}
