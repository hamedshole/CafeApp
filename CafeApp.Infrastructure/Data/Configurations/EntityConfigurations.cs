using CafeApp.Domain.Common;
using CafeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure.Data.Configurations
{
    internal class EntityConfigurations :

        IEntityTypeConfiguration<TableEntity>
        , IEntityTypeConfiguration<UnitEntity>
        , IEntityTypeConfiguration<MaterialEntity>
        , IEntityTypeConfiguration<AdditiveEntity>
        , IEntityTypeConfiguration<ProductCategoryEntity>
        , IEntityTypeConfiguration<ProductEntity>
        , IEntityTypeConfiguration<ProductMaterialEntity>
        , IEntityTypeConfiguration<ProductPriceLogEntity>
        , IEntityTypeConfiguration<AdditivePriceLogEntity>
        , IEntityTypeConfiguration<MaterialPriceLogEntity>
        , IEntityTypeConfiguration<OrderEntity>
        , IEntityTypeConfiguration<OrderItemEntity>
        , IEntityTypeConfiguration<OrderItemAdditiveEntity>
        , IEntityTypeConfiguration<UserEntity>
        , IEntityTypeConfiguration<CustomerEntity>
        , IEntityTypeConfiguration<InventoryEntity>
        , IEntityTypeConfiguration<InventoryLogEntity>
        , IEntityTypeConfiguration<UserRoleEntity>
        , IEntityTypeConfiguration<RoleEntity>
        , IEntityTypeConfiguration<InventoryFactorEntity>

    {


        public void Configure(EntityTypeBuilder<TableEntity> builder)
        {
          
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<UnitEntity> builder)
        {
            
            //builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.Parent).WithMany(x => x.Childs).HasForeignKey(x => x.ParentId);
        }

        public void Configure(EntityTypeBuilder<MaterialEntity> builder)
        {
            
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<AdditiveEntity> builder)
        {
           
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
           
            //builder.HasQueryFilter(x => !x.IsDeleted);
        }

        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<ProductMaterialEntity> builder)
        {
         
            builder.HasOne(x=>x.Unit)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            //builder.HasQueryFilter(x => !x.IsDeleted);
        }

        public void Configure(EntityTypeBuilder<ProductPriceLogEntity> builder)
        {
          
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<AdditivePriceLogEntity> builder)
        {
           
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<MaterialPriceLogEntity> builder)
        {
          
            //builder.HasQueryFilter(x => !x.IsDeleted);


        }

        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
           
            //builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.State).HasConversion(x => (byte)x, x =>  (FactorState)x);


        }

        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
           
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<OrderItemAdditiveEntity> builder)
        {
          
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
           
            builder.Property(propertyExpression: x => x.Gender).HasConversion(x => (byte)x, x => (Gender)x);
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
           
            //builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(propertyExpression: x => x.Gender).HasConversion(x => (byte)x, x => (Gender)x);
        }

        public void Configure(EntityTypeBuilder<InventoryEntity> builder)
        {
           
            //builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<InventoryLogEntity> builder)
        {

            //builder.HasQueryFilter(x => !x.IsDeleted);
            
            builder.Property(propertyExpression: x => x.State).HasConversion(x => (byte)x, x =>  (InventoryLogState)x);

        }

        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
          
        }

        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
           
        }

        public void Configure(EntityTypeBuilder<InventoryFactorEntity> builder)
        {
           
        }
    }
}
