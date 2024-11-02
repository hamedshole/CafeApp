using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        public int Order { get; private set; }
        public Guid CategoryId { get; private set; }
        public ProductCategoryEntity? Category { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public string Image { get; private set; }
        public bool IsNew { get; private set; }
        public long Price { get; private set; }
        public long  Cost { get; private set; }

        public bool IsActive { get; private set; }
        public ICollection<ProductMaterialEntity>? Materials { get; private set; }
        public ICollection<ProductAdditiveEntity>? Additives { get; private set; }
        public void UpdatePrice(long price) => Price = price;
        public void ChangeOrder(int order)=>Order = order;
        public void SetMaterials(ICollection<ProductMaterialEntity> materials) => Materials = materials;
        public void SetAdditives(ICollection<ProductAdditiveEntity> additives) => Additives = additives;

        public ProductEntity()
        {
            Title = string.Empty;
            Image = string.Empty;
            Category = null;
        }

        public ProductEntity(int order, Guid categoryId, string title, string? description, string image, bool isNew, long price, bool isActive)
        {
            Order = order;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            Image = image;
            IsNew = isNew;
            Price = price;
            IsActive = isActive;

        }
        public ProductEntity(Guid id, int order, Guid categoryId, string title, string? description, string image, bool isNew, long price, bool isActive) : base(id)
        {
            Order = order;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            Image = image;
            IsNew = isNew;
            Price = price;
            IsActive = isActive;

        }
    }
}