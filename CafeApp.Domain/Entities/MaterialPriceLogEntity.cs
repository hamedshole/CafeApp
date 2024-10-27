using CafeApp.Domain.Common;
using CafeApp.Domain.ValueObjects;

namespace CafeApp.Domain.Entities
{
    public class MaterialPriceLogEntity:EntityBase
    {
        public Guid MaterialId { get; set; }
        public MaterialEntity? Material { get; set; }
        public Money    Price{ get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
