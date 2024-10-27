using CafeApp.Domain.Common;
using CafeApp.Domain.ValueObjects;

namespace CafeApp.Domain.Entities
{
    public class OrderEntity:EntityBase
    {
        public FactorState State { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public DateTime Time { get; set; }
        public Guid? CustomerId { get; set; }
        public CustomerEntity? Customer { get; set; }
        public FactorType Type { get; set; }
        public Guid? TableId { get; set; }
        public TableEntity? Table { get; set; }
        public Money TotalPrice{ get; set; }
        public bool HasDiscount { get; set; }
        public Money PaidAmount { get; set; }
        public Money TotalCost { get; set; }
        public string? Description { get; set; }
        public ICollection<OrderDetailEntity>? Details { get; set; }
    }
}
