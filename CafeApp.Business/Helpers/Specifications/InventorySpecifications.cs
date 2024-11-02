using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    public class InventorySpecifications:BaseSpecification<InventoryEntity>
    {
        public InventorySpecifications AddFilters(ListInventoryParameter parameter)
        {
            if(!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));
          
            if(parameter.IsActive.HasValue )
                SetFilterCondition(x=>x.IsActive==parameter.IsActive.Value);
            return this;
        }
    }
}
