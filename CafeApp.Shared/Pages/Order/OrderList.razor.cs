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
                ICollection<OrderEntity> _apiEntities = await _restUnit.Orders.Sync();
                foreach (OrderEntity dbEntity in _apiEntities)
                {
                    await _unit.Orders.WriteSync(dbEntity);
                }
                await _unit.Orders.Apply();
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public void GoToDetails(Guid id)
        {
            _navigation.NavigateTo($"/dashboard/order/{id}");
        }
        public string GetChangeStateButtonStyle(string state, string button)
        {
            if (state.Equals(button))
                if (state.Equals("لغو"))
                    return "background-color:red;margin:5px;disabled:true";
                else
                    return "background-color:yellow;margin:5px;disabled:true";
            else
                return "background-color:slategrey;margin:5px";

        }
        public bool GetStateButtonEnable(string state, string button)
        {
            return state.Equals(button);

        }
        public async Task ChangeState(Guid orderId, short state)
        {
            await _unit.Orders.ChangeState(orderId, state);
            await _dataGrid.ReloadServerData();
        }
    }
}
