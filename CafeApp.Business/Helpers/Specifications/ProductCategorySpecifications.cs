using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    internal class ProductCategorySpecifications : BaseSpecification<ProductCategoryEntity>
    {
        public ProductCategorySpecifications()
        {

        }
        public ProductCategorySpecifications(ListProductCategoryParameter parameter)
        {
            if (parameter.IsActive is bool i)
                SetFilterCondition(x => x.IsActive == i);
            if (string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x => x.Title.Contains(parameter.Title!));
        }

    }
}
