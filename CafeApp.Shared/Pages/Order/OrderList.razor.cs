using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using MudBlazor;

namespace CafeApp.Shared.Pages.Order
{
    public partial class OrderList
    {
        private readonly string _route = "orders";
        private async Task<GridData<OrderDto>> LoadData(GridState<OrderDto> gridState)
        {
            ListOrderParameter parameter = new ListOrderParameter();
            parameter.PageSize = gridState.PageSize;
            parameter.Page = gridState.Page + 1;
            var res = await _unit.Orders.GetPaged(parameter.GetSpecifications(), parameter);
            if (res.Items is null)
                res = new PagedList<OrderDto>(new List<OrderDto>(), res.TotalItems);
            return new GridData<OrderDto> { Items = res.Items, TotalItems = res.TotalItems };
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
            await _unit.Orders.DeleteAsync(id);
        }
        public async Task Sync()
        {
            try
            {
                ICollection<OrderEntity> dbEntities = await _unit.Orders.GetAllForSync();
                foreach (OrderEntity dbEntity in dbEntities)
                {
                    await _restUnit.Orders.WriteSync(dbEntity);
                }
                await _restUnit.Orders.Apply();
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
