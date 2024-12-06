using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Common;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class OrderService(IRepository<OrderEntity> repository, IMapper mapper) : BaseService<OrderEntity, OrderDto, DashboardFactorModel>(repository, mapper), IOrderService
    {
        public async Task ApplyDeliver(DashboardFactorItemModel item, Guid orderId)
        {
            var orderItem = _repository.DataUnit.OrderItems.Get(x => x.Id == item.Id && x.OrderId == orderId).FirstOrDefault();
            orderItem.Delivered = item.StateChecked;
            await _repository.DataUnit.SaveChangesAsync();
            bool allDelivered = _repository.DataUnit.OrderItems.Get(x => x.OrderId == orderId).All(x => x.Delivered == true);
            if (allDelivered)
            {
                await ChangeState(orderId, (short)FactorState.Completed);
            }
        }

        public async Task ChangeState(Guid orderId, short state)
        {
            var order = _repository.Get(x => x.Id == orderId).FirstOrDefault()!;
            order.State = (FactorState)state;
            order.Update(Guid.Empty);
            await _repository.UpdateAsync(order);
            await _repository.DataUnit.SaveChangesAsync();
        }

        public async Task PayOrder(Guid orderId, long paidValue)
        {
            var order = _repository.Get(x => x.Id == orderId).FirstOrDefault();
            order.PaidAmount = paidValue;
            await _repository.UpdateAsync(order);
            await _repository.DataUnit.SaveChangesAsync();
        }
        public async Task PayOrderItem(Guid orderId, Guid orderItemId, int amount)
        {
            var orderItem = _repository.DataUnit.OrderItems.Get(x => x.Id == orderItemId && x.OrderId == orderId).FirstOrDefault();
            orderItem.PaidAmount = amount;
            await _repository.DataUnit.SaveChangesAsync();
        }
        public override async Task UpdateAsync<TParameter>(TParameter parameter)
        {
            UpdateOrderParameter model = parameter as UpdateOrderParameter;

            OrderEntity entity = _repository.Get(OrderSpecifications.GetOrder(model.Id)).FirstOrDefault()!;
          
            entity.TableId = model.TableId;
            if (model.CustomerId != Guid.Empty)
                entity.CustomerId = entity.CustomerId;
            entity.Description = model.Description;
            entity = _mapper.Map<OrderEntity>(model);
            await _repository.UpdateAsync(entity);
            await _repository.DataUnit.SaveChangesAsync();
        }
    }
}
