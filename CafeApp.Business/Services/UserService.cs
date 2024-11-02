using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class UserService(IRepository<UserEntity> repository, IMapper mapper) : BaseService<UserEntity, UserDto>(repository, mapper), IUserService
    {
        
    }
}
