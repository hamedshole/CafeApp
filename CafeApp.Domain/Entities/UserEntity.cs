using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class UserEntity:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
