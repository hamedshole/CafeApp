using CafeApp.Domain.Common;
using CafeApp.Domain.ValueObjects;

namespace CafeApp.Domain.Entities
{
    public class ProductPriceLogEntity:EntityBase
    {
        public Guid ProductId { get; set; }
        public PayoutEntity? Product { get; set; }
        public Money Price{ get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
