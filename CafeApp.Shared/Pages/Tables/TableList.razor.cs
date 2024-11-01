using CafeApp.Business.Helpers.Dtos;
using MudBlazor;

namespace CafeApp.Shared.Pages.Tables
{
    public partial class TableList
    {
       

        public async Task<GridData<TableDto>> LoadData(GridState<TableDto> state)
        {
            ListTableParameter parameter = new ListTableParameter();
            parameter.PageSize = state.PageSize;
            parameter.Page=state.Page;
            var res= await _unit.Tables.GetPaged(parameter.GetSpecifications(), parameter);
            return new GridData<TableDto> { Items=res.Items,TotalItems=res.TotalItems };
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo("/dashboard/tables/new");
    }
    }
}
