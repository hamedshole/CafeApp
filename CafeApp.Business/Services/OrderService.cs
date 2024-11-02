using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class OrderService(IRepository<OrderEntity> repository, IMapper mapper) : BaseService<OrderEntity, OrderDto>(repository, mapper), IOrderService
    {
    }
}
