using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Common;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class OrderService(IRepository<OrderEntity> repository, IMapper mapper) : BaseService<OrderEntity, OrderDto,DashboardFactorModel>(repository, mapper), IOrderService
    {
        public async Task ChangeState(Guid orderId, short state)
        {
            var order = await _repository.GetByIdAsync(orderId);
            order.State = (FactorState)state;
            order.Update(Guid.Empty);
            await _repository.UpdateAsync(order);
            await _repository.DataUnit.SaveChangesAsync();
        }
    }
}
