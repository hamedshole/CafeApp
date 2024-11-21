using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using MudBlazor;
namespace CafeApp.Shared.Pages.Category
{
    public partial class CategoryList
    {
        private CategoryDetail _panel;
        private async Task<GridData<ProductCategoryDto>> LoadData(GridState<ProductCategoryDto> gridState)
        {
            ListProductCategoryParameter parameter = new ListProductCategoryParameter();
            parameter.PageSize=gridState.PageSize;
            parameter.Page=gridState.Page+1;
            var res = await _unit.Categories.GetPaged(parameter.GetSpecifications(),parameter);
            if (res.Items is null)
                res = new PagedList<ProductCategoryDto>(new List<ProductCategoryDto>(), res.TotalItems);
            return new GridData<ProductCategoryDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo("/dashboard/categories/new");
        }
        public void Edit(Guid id)
        {
            _navigation.NavigateTo("/dashboard/categories/" + id);

        }
        public async Task Delete(Guid id)
        {
            await _unit.Tables.DeleteAsync(id);
        }
        public async Task Sync()
        {
            try
            {
                ICollection<ProductCategoryEntity> dbEntities = await _unit.Categories.GetAllForSync();
                foreach (ProductCategoryEntity dbEntity in dbEntities)
                {
                    await _restUnit.Categories.WriteSync(dbEntity);
                }
                await _restUnit.Categories.Apply();
                ICollection<ProductCategoryEntity> apiEntities = await _restUnit.Categories.Sync();
                foreach (ProductCategoryEntity dbEntity in apiEntities)
                {
                    await _unit.Categories.WriteSync(dbEntity);
                }
                await _unit.Categories.Apply();
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
    }

}
