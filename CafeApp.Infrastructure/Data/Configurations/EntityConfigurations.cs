using CafeApp.Domain.Common;
using CafeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.Infrastructure.Data.Configurations
{
    internal class EntityConfigurations : IEntityTypeConfiguration<ProductEntity>,IEntityTypeConfiguration<ProductPriceLogEntity>,IEntityTypeConfiguration<PayoutEntity>
        ,IEntityTypeConfiguration<OrderEntity>,IEntityTypeConfiguration<MaterialPriceLogEntity>,IEntityTypeConfiguration<MaterialEntity>,
        IEntityTypeConfiguration<UserEntity>,IEntityTypeConfiguration<CustomerEntity>,IEntityTypeConfiguration<ProductMaterialEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.Price).HasConversion(x => x.GetValue(), x => new Domain.ValueObjects.Money(x));
            builder.Property(x => x.Cost).HasConversion(x => x.GetValue(), x => new Domain.ValueObjects.Money(x));

        }

        public void Configure(EntityTypeBuilder<ProductPriceLogEntity> builder)
        {
            builder.Property(x => x.Price).HasConversion(x => x.GetValue(), x => new Domain.ValueObjects.Money(x));
        }

        public void Configure(EntityTypeBuilder<PayoutEntity> builder)
        {
            builder.Property(x => x.Amount).HasConversion(x => x.GetValue(), x => new Domain.ValueObjects.Money(x));
        }

        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.Property(x => x.PaidAmount).HasConversion(x => x.GetValue(), x => new Domain.ValueObjects.Money(x));
            builder.Property(x => x.TotalPrice).HasConversion(x => x.GetValue(), x => new Domain.ValueObjects.Money(x));
            builder.Property(x => x.TotalCost).HasConversion(x => x.GetValue(), x => new Domain.ValueObjects.Money(x));
        }

        public void Configure(EntityTypeBuilder<MaterialPriceLogEntity> builder)
        {
            builder.Property(x => x.Price).HasConversion(x => x.GetValue(), x => new Domain.ValueObjects.Money(x));
        }

        public void Configure(EntityTypeBuilder<MaterialEntity> builder)
        {
            builder.Property(x => x.UnitPrice).HasConversion(x => x.GetValue(), x => new Domain.ValueObjects.Money(x));
        }

        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.Property(x => x.Gender).HasConversion(x => Convert.ToBoolean(x), x => (Gender)Convert.ToInt16(x));
        }

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.Gender).HasConversion(x => Convert.ToBoolean(x), x => (Gender)Convert.ToInt16(x));
        }

        public void Configure(EntityTypeBuilder<ProductMaterialEntity> builder)
        {
            builder.HasOne(pm => pm.Unit)
                            .WithMany()
                            .HasForeignKey(x => x.UnitId)
                            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
