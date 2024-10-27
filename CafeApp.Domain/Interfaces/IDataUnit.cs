using CafeApp.Domain.Entities;

namespace CafeApp.Domain.Interfaces
{
    public interface IDataUnit
    {
        //ISignInManager SignInManager { get; }
        //IUserManager UserManager { get; }
        ISql Sql { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        IRepository<TableEntity> Tables { get; }
        IRepository<MaterialEntity> Materials { get; }
        IRepository<UnitEntity> Units { get; }
        IRepository<ProductCategoryEntity> Categories { get; }
        IRepository<ProductEntity> Products { get; }
        IRepository<ProductMaterialEntity> ProductMaterials { get; }
        IRepository<MaterialPriceLogEntity> MaterialPriceLogs { get; }
        IRepository<ProductPriceLogEntity> ProductPriceLogs { get; }
        IRepository<CustomerEntity> Customers { get; }
        IRepository<InventoryEntity> Inventories { get; }
        IRepository<InventoryLogEntity> InventoryLogs { get; }
        IRepository<OrderEntity> Orders { get; }
        IRepository<OrderDetailEntity> OrderDetails { get; }
        IRepository<PayoutEntity> Payouts { get; }
        IRepository<UserEntity> Users { get; }
        IRepository<RoleEntity> Roles { get; }
        IRepository<UserRoleEntity> UserRoles { get; }
        IAuth Auth { get; }

    }
}
