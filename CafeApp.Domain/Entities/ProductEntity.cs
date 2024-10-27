using CafeApp.Domain.Common;
using CafeApp.Domain.ValueObjects;

namespace CafeApp.Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        public Guid CategoryId { get; set; }
        public ProductCategoryEntity? Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public Money Price { get; set; }
        public Money Cost { get; set; }
        public bool IsActive { get; set; }
        public bool OutOfStock { get; set; }

        public ICollection<ProductMaterialEntity>? Materials { get; set; }

        public ProductEntity()
        {

        }
    }
}