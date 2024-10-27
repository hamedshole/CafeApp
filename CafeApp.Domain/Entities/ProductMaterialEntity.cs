using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class ProductMaterialEntity:EntityBase
    {
        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public Guid MaterialId { get; set; }
        public MaterialEntity? Material { get; set; }
        public Guid UnitId { get; set; }
        public UnitEntity? Unit { get; set; }
        public double Amount { get; set; }
    }
}