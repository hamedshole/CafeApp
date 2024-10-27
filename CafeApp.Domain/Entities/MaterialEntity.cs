using CafeApp.Domain.Common;
using CafeApp.Domain.ValueObjects;

namespace CafeApp.Domain.Entities
{
    public class MaterialEntity:EntityBase
    {
        public string Title { get; set; }
        public Guid UnitId { get; set; }
        public UnitEntity? Unit { get; set; }
        public Money UnitPrice{ get; set; }
        public bool IsActive { get; set; }
    }
}
