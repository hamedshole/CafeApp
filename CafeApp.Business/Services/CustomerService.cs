using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class CustomerService(IRepository<CustomerEntity> repository, IMapper mapper) : BaseService<CustomerEntity, CustomerDto>(repository, mapper), ICustomerService
    {
    }
}
