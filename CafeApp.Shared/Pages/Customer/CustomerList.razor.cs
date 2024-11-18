﻿using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using MudBlazor;
namespace CafeApp.Shared.Pages.Customer
{
    public partial class CustomerList
    {
        private readonly string _route = "customers";
        private async Task<GridData<CustomerDto>> LoadData(GridState<CustomerDto> gridState)
        {
            ListCustomerParameter parameter = new ListCustomerParameter();
            parameter.PageSize = gridState.PageSize;
            parameter.Page = gridState.Page + 1;
            var res = await _unit.Customers.GetPaged(parameter.GetSpecifications(), parameter);
            if (res.Items is null)
                res = new PagedList<CustomerDto>(new List<CustomerDto>(), res.TotalItems);
            return new GridData<CustomerDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo($"/dashboard/{_route}/new");
        }
        public void Edit(Guid id)
        {
            _navigation.NavigateTo($"/dashboard/{_route}/" + id);

        }
        public async Task Delete(Guid id)
        {
            await _unit.Customers.DeleteAsync(id);
        }
        public async Task Sync()
        {
            try
            {
                ICollection<CustomerEntity> dbEntities = await _unit.Customers.GetAllForSync();
                foreach (CustomerEntity dbEntity in dbEntities)
                {
                    await _restUnit.Customers.WriteSync(dbEntity);
                }
                await _restUnit.Customers.Apply();
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }

}