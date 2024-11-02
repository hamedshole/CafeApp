using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    public class OrderSpecifications : BaseSpecification<OrderEntity>
    {
        public OrderSpecifications AddFilter(ListOrderParameter parameter)
        {
            if (parameter.CustomerId is Guid ci)
                SetFilterCondition(x => x.CustomerId==ci);
            if (parameter.TableId is Guid ti)
                SetFilterCondition(x => x.TableId == ti);
            if (parameter.Start.HasValue)
                SetFilterCondition(x => x.Time >= parameter.Start);
            if (parameter.End.HasValue)
                SetFilterCondition(x => x.Time <= parameter.End);
            if (parameter.State.HasValue)
                SetFilterCondition(x => (byte)x.State == parameter.State);

            return this;
        }
        public OrderSpecifications AddIncludes()
        {
            AddInclude(nameof(OrderEntity.Table));
            AddInclude(nameof(OrderEntity.Customer));

            return this;
        }
    }
}
