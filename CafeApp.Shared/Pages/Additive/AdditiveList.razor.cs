using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using MudBlazor;

namespace CafeApp.Shared.Pages.Additive
{
    public partial class AdditiveList
    {
        private AdditiveDetail _panel;
        private async Task<GridData<AdditiveDto>> LoadData(GridState<AdditiveDto> gridState)
        {
            ListAdditiveParameter parameter = new ListAdditiveParameter();
            parameter.Page=gridState.Page+1;
            parameter.PageSize=gridState.PageSize;
            var res = await _unit.Additives.GetPaged(parameter.GetSpecifications(),parameter);
            if (res.Items is null)
                res = new PagedList<AdditiveDto>(new List<AdditiveDto>(), res.TotalItems);
            return new GridData<AdditiveDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(Guid id)
        {
            await _unit.Additives.DeleteAsync(id);
            await _dataGrid.ReloadServerData();
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo("/dashboard/additives/new");
        }
        public void Edit(Guid id)
        {
            _navigation.NavigateTo("/dashboard/additives/" + id);

        }
        public async Task Sync()
        {
            try
            {
                ICollection<AdditiveEntity> dbEntities = await _unit.Additives.GetAllForSync();

                foreach (AdditiveEntity dbEntity in dbEntities)
                {
                    dbEntity.ClearRelations();
                    await _restUnit.Additives.WriteSync(dbEntity);
                }
                await _restUnit.Additives.Apply();
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
