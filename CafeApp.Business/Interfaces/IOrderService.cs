using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Interfaces
{
    public interface IOrderService:IBaseService<OrderEntity,OrderDto,DashboardFactorModel>
    {
        Task ChangeState(Guid orderId, short state);
    }
}
