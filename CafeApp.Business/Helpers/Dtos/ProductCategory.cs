using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class ProductCategoryModel
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public ICollection<ProductModel> Items { get; set; }
    }

    public class ListProductCategoryParameter : PagingParameter, IGetParameter<ProductCategoryEntity>
    {
        public bool? IsActive { get; set; }
        public string? Title { get; set; }
        public ISpecifications<ProductCategoryEntity> GetSpecifications()
        {
            return new ProductCategorySpecifications(this);
        }
    }

    public class CreateProductCategoryParameter
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
    }
    public class UpdateProductCategoryParameter : CreateProductCategoryParameter
    {

        public Guid Id { get; set; }

    }
}
