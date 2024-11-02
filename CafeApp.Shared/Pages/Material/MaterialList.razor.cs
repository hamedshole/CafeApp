using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using MudBlazor;

namespace CafeApp.Shared.Pages.Material
{
    public partial class MaterialList
    {
        private MaterialDetail _panel;
        private async Task<GridData<MaterialDto>> LoadData(GridState<MaterialDto> gridState)
        {
            ListMaterialParameter parameter = new ListMaterialParameter();
            parameter.PageSize=gridState.PageSize;
            parameter.Page=gridState.Page+1;
            var res = await _unit.Materials.GetPaged(parameter.GetSpecifications(),parameter);
            if (res.Items is null)
                res = new PagedList<MaterialDto>(new List<MaterialDto>(), res.TotalItems);
            return new GridData<MaterialDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo("/dashboard/materials/new");
        }
        public void Edit(Guid id)
        {
            _navigation.NavigateTo("/dashboard/materials/" + id);

        }
        public async Task Delete(Guid id)
        {
            await _unit.Materials.DeleteAsync(id);
        }
        public async Task Sync()
        {
            try
            {
                ICollection<MaterialEntity> dbEntities = await _unit.Materials.GetAllForSync();

                foreach (MaterialEntity dbEntity in dbEntities)
                {
                    dbEntity.ClearRelations();
                    await _restUnit.Materials.WriteSync(dbEntity);
                }
                await _restUnit.Materials.Apply();
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
