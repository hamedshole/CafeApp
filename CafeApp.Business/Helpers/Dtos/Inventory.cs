using CafeApp.Business.Helpers.Common;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class InventoryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string IsActive { get; set; }
        public InventoryDto()
        {
            
        }
    }
    public class CreateInventoryParameter
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public CreateInventoryParameter()
        {
            
        }
    }
    public class UpdateInventoryParameter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
    public class ListInventoryParameter:PagingParameter,IGetParameter<InventoryEntity>
    {
        public string? Title { get; set; }
        public bool? IsActive { get; set; }

        public ISpecifications<InventoryEntity> GetSpecifications()
        {
            throw new NotImplementedException();
        }
    }
}
