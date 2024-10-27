using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;
using CafeApp.Infrastructure.Data.Context;
using CafeApp.Infrastructure.Data.Repositories;
using CafeApp.Infrastructure.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Infrastructure.Data
{
    internal class DataUnit : IDataUnit
    {
        private readonly CafeDbContext _dbContext;
        private readonly string _connectionString;


        private readonly SqlRepository _sql;
        private DataRepository<TableEntity>? _tablerepository;
        private DataRepository<MaterialEntity>? _materialRepository;
        private DataRepository<UnitEntity>? _unitRepository;
        private DataRepository<ProductCategoryEntity>? _ctegoryRepository;
        private DataRepository<ProductEntity>? _productRepository;
        private DataRepository<ProductMaterialEntity>? _productMaterialRepository;
        private DataRepository<MaterialPriceLogEntity>? _materialPriceLogRepository;
        private DataRepository<ProductPriceLogEntity>? _productPriceLogRepository;
        private DataRepository<CustomerEntity>? _customerRepository;
        private DataRepository<InventoryEntity>? _inventoryRepository;
        private DataRepository<InventoryLogEntity>? _inventoryLogRepository;
        private DataRepository<OrderEntity>? _orderRepository;
        private DataRepository<OrderDetailEntity>? _orderDetailRepository;
        private DataRepository<PayoutEntity>? _payoutRepository;
        private DataRepository<UserEntity>? _userRepository;
        private DataRepository<RoleEntity>? _roleRepository;
        private DataRepository<UserRoleEntity>? _userRoleRepository;

        private IAuth _auth;
        public DataUnit(CafeDbContext context,DbOptions dbOptions,IAuth auth)
        {
            this._auth=auth;
            _dbContext = context;
            _connectionString = dbOptions.ConnectionString;
        }
        public ISql Sql => _sql ?? new SqlRepository(_connectionString);

        public IRepository<TableEntity> Tables => _tablerepository ?? new DataRepository<TableEntity>(_dbContext, this);

        public IRepository<MaterialEntity> Materials => _materialRepository??new DataRepository<MaterialEntity>(_dbContext, this);

        public IRepository<UnitEntity> Units => _unitRepository??new DataRepository<UnitEntity>(_dbContext, this);

        public IRepository<ProductCategoryEntity> Categories => _ctegoryRepository??new DataRepository<ProductCategoryEntity>(_dbContext, this);

        public IRepository<ProductEntity> Products => _productRepository??new DataRepository<ProductEntity>(_dbContext,this);

        public IRepository<ProductMaterialEntity> ProductMaterials => _productMaterialRepository??new DataRepository<ProductMaterialEntity>(_dbContext, this);

        public IRepository<MaterialPriceLogEntity> MaterialPriceLogs => _materialPriceLogRepository??new DataRepository<MaterialPriceLogEntity>(_dbContext, this);  

        public IRepository<ProductPriceLogEntity> ProductPriceLogs => _productPriceLogRepository??new DataRepository<ProductPriceLogEntity>(_dbContext, this);

        public IRepository<CustomerEntity> Customers => _customerRepository??new DataRepository<CustomerEntity>(_dbContext, this);

        public IRepository<InventoryEntity> Inventories => _inventoryRepository??new DataRepository<InventoryEntity>(_dbContext, this);

        public IRepository<InventoryLogEntity> InventoryLogs => _inventoryLogRepository??new DataRepository<InventoryLogEntity>(_dbContext, this);

        public IRepository<OrderEntity> Orders => _orderRepository??new DataRepository<OrderEntity>(_dbContext, this);

        public IRepository<OrderDetailEntity> OrderDetails => _orderDetailRepository??new DataRepository<OrderDetailEntity>(_dbContext, this);

        public IRepository<PayoutEntity> Payouts => _payoutRepository??new DataRepository<PayoutEntity>(_dbContext, this);

        public IRepository<UserEntity> Users => _userRepository??new DataRepository<UserEntity>(_dbContext, this);

        public IRepository<RoleEntity> Roles => _roleRepository??new DataRepository<RoleEntity>(_dbContext, this);

        public IRepository<UserRoleEntity> UserRoles => _userRoleRepository??new DataRepository<UserRoleEntity>(_dbContext, this);

        public IAuth Auth => _auth;

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)=>await _dbContext.SaveChangesAsync(cancellationToken);

    }
}
