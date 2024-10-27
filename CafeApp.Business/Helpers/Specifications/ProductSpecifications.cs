using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    internal class ProductSpecifications : BaseSpecification<ProductEntity>
    {
        public ProductSpecifications()
        {

        }
        public ProductSpecifications(ListProductParameter parameter)
        {
            if (parameter.IsActive is bool i)
                SetFilterCondition(x => x.IsActive == i);
            if (parameter.IsNew is bool isNew)
                SetFilterCondition(x => x.IsNew == isNew);
            if (parameter.OutOfStock is bool outof)
                SetFilterCondition(x => x.OutOfStock == outof);
            if (parameter.CategoryId is Guid categoryId)
                SetFilterCondition(x => x.CategoryId == categoryId);
            if (string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x => x.Title.Contains(parameter.Title!));
        }
    }
}
