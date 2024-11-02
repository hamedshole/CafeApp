using CafeApp.Business.Helpers.Common;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public string State { get; set; }
        public string? Customer { get; set; }
        public string Table { get; set; }
        public string TotalPrice { get; set; }
        public OrderDto()
        {
            
        }
    }
    public class CreateOrderItemAdditiveParameter
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
    }
    public class CreateOrderItemParameter
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public bool HasAdditive { get; set; }
        public ICollection<CreateOrderItemAdditiveParameter>? Additives { get; set; }
        public CreateOrderItemParameter()
        {
            
        }
    }
    public class CreateOrderParameter
    {
        public Guid? CustomerId { get; set; }
        public Guid TableId { get; set; }
        public ICollection<CreateOrderItemParameter> Items{ get; set; }
        public CreateOrderParameter()
        {
            
        }
    }
    public class ListOrderParameter:PagingParameter,IGetParameter<OrderEntity>
    {
        public byte? State { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? TableId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public ListOrderParameter()
        {
            
        }

        public ISpecifications<OrderEntity> GetSpecifications()
        {
            throw new NotImplementedException();
        }
    }
}
