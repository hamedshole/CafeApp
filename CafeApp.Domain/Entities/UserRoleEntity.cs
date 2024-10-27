using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class UserRoleEntity:EntityBase
    {
        public Guid RoleId { get; set; }
        public RoleEntity? Role { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Get { get; set; }
        public bool IsActive { get; set; }
    }
}
