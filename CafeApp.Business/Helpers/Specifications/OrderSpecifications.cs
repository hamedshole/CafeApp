using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    public class OrderSpecifications : BaseSpecification<OrderEntity>
    {
        public static OrderSpecifications FromParameter(ListOrderParameter parameter)
        {
            OrderSpecifications orderSpecifications = new OrderSpecifications();
            orderSpecifications.AddFilter(parameter);
            orderSpecifications.AddInclude("Customer");
            return orderSpecifications;
        }

        public static OrderSpecifications GetTableState(Guid tableId)
        {
            OrderSpecifications orderSpecifications=new OrderSpecifications();
            orderSpecifications.SetFilterCondition(x => x.TableId == tableId);
            orderSpecifications.SetFilterCondition(x => x.State == Domain.Common.FactorState.InProgress);
            orderSpecifications.SetFilterCondition(x=>x.Time==DateTime.Now);
            return orderSpecifications;
        }
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
