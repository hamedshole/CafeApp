using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using MudBlazor;

namespace CafeApp.Shared.Pages.Unit
{
    public partial class UnitList
    {
        private UnitDetail _panel;
        private async Task<GridData<UnitDto>> LoadData(GridState<UnitDto> gridState)
        {
            ListUnitParameter parameter = new ListUnitParameter();
            parameter.PageSize=gridState.PageSize;
            parameter.Page=gridState.Page+1;
            var res = await _unit.Units.GetPaged(parameter.GetSpecifications(),parameter);
            if (res.Items is null)
                res = new PagedList<UnitDto>(new List<UnitDto>(), res.TotalItems);
            return new GridData<UnitDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(Guid id)
        {
            await _unit.Units.DeleteAsync(id);
            await _dataGrid.ReloadServerData();
        }
        public async Task Sync()
        {
            try
            {
                ICollection<UnitEntity> dbEntities = await _unit.Units.GetAllForSync();

                foreach (UnitEntity dbEntity in dbEntities)
                {
                    dbEntity.ClearRelations();
                    await _restUnit.Units.WriteSync(dbEntity);
                }
                await _restUnit.Products.Apply();
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
