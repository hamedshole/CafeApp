using CafeApp.Business.Helpers.Specifications;
using CafeApp.Business.Helpers.Common;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool OutOfStock { get; set; }
        public bool IsActive { get; set; }
    }

    public class ProductMaterialModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public long Amount { get; set; }
    }
    public class CreateProductParameter
    {

        public int Order { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CreateProductMaterialParameter>? Materials { get; set; }
    }
    public class UpdateProductParameter
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CreateProductMaterialParameter>? Materials { get; set; }
    }
    public class CreateProductMaterialParameter
    {

        public Guid MaterialId { get; set; }
        public long Amount { get; set; }
    }


    public class ListProductParameter : PagingParameter, IGetParameter<ProductEntity>
    {
        public Guid? CategoryId { get; set; }
        public string? Title { get; set; }
        public long? Price { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsNew { get; set; }
        public bool? OutOfStock { get; set; }

        public ISpecifications<ProductEntity> GetSpecifications()
        {
            return new ProductSpecifications(this);
        }
    }
    public class MenuProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsNew { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        //public ICollection<MenuAdditiveModel>? Additives { get; set; }
    }
    public class DashboardProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public long Price { get; set; }
    }
}
