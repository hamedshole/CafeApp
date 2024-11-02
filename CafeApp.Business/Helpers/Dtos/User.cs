using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class UserDto
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Birthday { get; set; }
        public string Username { get; set; }
        public UserDto()
        {

        }
    }
    public class CreateUserRoleParameter
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
    public class CreateUserParameter
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<CreateUserRoleParameter> Roles { get; set; }
        public CreateUserParameter()
        {

        }
    }
    public class UpdateUserParameter
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<CreateUserRoleParameter>? Roles { get; set; }
        public UpdateUserParameter()
        {

        }
    }

    public class GetUserParameter : IGetParameter<UserEntity>
    {
        public Guid Id { get; set; }

        public GetUserParameter(Guid id)
        {
            Id = id;
        }

        public ISpecifications<UserEntity> GetSpecifications()
        {
            return UserSpecifications.Get(this);
        }
    }
    public class ListUserParameter : PagingParameter, IGetParameter<UserEntity>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Username { get; set; }

        public ISpecifications<UserEntity> GetSpecifications()
        {
            throw new NotImplementedException();
        }
    }
}
