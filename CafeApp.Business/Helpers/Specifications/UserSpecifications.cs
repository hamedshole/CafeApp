using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    internal class UserSpecifications :BaseSpecification<UserEntity>
    {
        private void FromParaemterMethod(ListUserParameter parameter)
        {
           

        }
        private void GetMethod(Guid id)
        {
            SetFilterCondition(x=>x.Id==id);
            AddInclude(nameof(UnitEntity.Parent));
        }
        public static UserSpecifications FromParameter(ListUserParameter listParameter)
        {
            UserSpecifications specs = new UserSpecifications();
            specs.FromParaemterMethod(listParameter);
            return specs;
        }
        public static UserSpecifications Get(GetUserParameter parameter)
        {
            UserSpecifications specs = new UserSpecifications();
            specs.GetMethod(parameter.Id);
            return specs;
        }


    }
}
