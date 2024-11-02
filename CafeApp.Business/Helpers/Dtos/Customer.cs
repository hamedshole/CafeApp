using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthday { get; set; }
        public CustomerDto()
        {

        }

    }
    public class CreateCustomerParameter
    {
        public int Code { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
    }
    public class UpdateCustomerParameter
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
    }

    public class GetCategoryParameter : IGetParameter<ProductCategoryEntity>
    {
        public Guid Id { get; set; }

        public GetCategoryParameter(Guid id)
        {
            Id = id;
        }

        public ISpecifications<ProductCategoryEntity> GetSpecifications()
        {
            return ProductCategorySpecifications.Get(this);
        }
    }
    public class ListCustomerParameter : PagingParameter, IGetParameter<CustomerEntity>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }

        public ISpecifications<CustomerEntity> GetSpecifications()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
