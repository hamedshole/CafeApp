using CafeApp.Business.Helpers.Dtos;
using MudBlazor;

namespace CafeApp.Shared.Pages.Inventories
{
    public partial class InventoryList
    {


        public async Task<GridData<InventoryDto>> LoadData(GridState<InventoryDto> state)
        {
            try
            {

            ListInventoryParameter parameter = new ListInventoryParameter();
            parameter.PageSize = state.PageSize;
            parameter.Page = state.Page+1;
            var res = await _unit.Inventories.GetPaged(parameter.GetSpecifications(), parameter);
            return new GridData<InventoryDto> { Items = res.Items, TotalItems = res.TotalItems };
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo("/dashboard/inventories/new");
        }
        public void Edit(Guid id)
        {
            _navigation.NavigateTo("/dashboard/inventories/" + id);

        }
        public async Task Delete(Guid id)
        {
           await _unit.Tables.DeleteAsync(id);
            _notification.NotifySuccess();
        }
    }
}
