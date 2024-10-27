using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class OrderDetailEntity:EntityBase
    {
        public Guid FactorId { get; set; }
        public OrderEntity? Factor { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
    }
}