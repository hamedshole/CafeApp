﻿using CafeApp.Business.Helpers.Dtos;
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

        public static OrderSpecifications GetTableOrder(Guid tableId)
        {
            OrderSpecifications specs=new OrderSpecifications();
            specs.SetFilterCondition(x=>x.TableId == tableId);
            specs.SetFilterCondition(x => x.State == Domain.Common.FactorState.New || x.State == Domain.Common.FactorState.InProgress);
            specs.SetFilterCondition(x => DateOnly.FromDateTime(x.Time) == DateOnly.FromDateTime(DateTime.Now));
            specs.AddInclude("Details");
            specs.AddInclude("Table");
            specs.AddInclude("Customer");
            return specs;

        }
        public static OrderSpecifications GetOrder(Guid orderId)
        {
            OrderSpecifications specs = new OrderSpecifications();
            specs.SetFilterCondition(x => x.Id == orderId);
            specs.AddInclude("Details.Product");
            specs.AddInclude("Table");
            specs.AddInclude("Customer");
            return specs;

        }

        public static OrderSpecifications GetTableState(Guid tableId)
        {
            OrderSpecifications specs = new OrderSpecifications();
            specs.SetFilterCondition(x => x.TableId == tableId);
            specs.SetFilterCondition(x => x.State == Domain.Common.FactorState.New || x.State == Domain.Common.FactorState.InProgress);
            specs.SetFilterCondition(x => DateOnly.FromDateTime(x.Time) == DateOnly.FromDateTime(DateTime.Now));
            specs.AddInclude("Details.Product");
            specs.AddInclude("Table");
            specs.AddInclude("Customer");
            return specs;
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
            if (parameter.State.HasValue && parameter.State.Value!=0)
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
