using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using MudBlazor;

namespace CafeApp.Shared.Pages.Product
{
    public partial class ProductList
    {
        private ProductDetail _panel;
        private async Task<GridData<ProductDto>> LoadData(GridState<ProductDto> gridState)
        {
            ListProductParameter parameter=new ListProductParameter();
            parameter.Page = gridState.Page + 1;
            parameter.PageSize = gridState.PageSize;
            var res = await _unit.Products.GetPaged(parameter.GetSpecifications(),parameter);
            if (res.Items is null)
                res = new PagedList<ProductDto>(new List<ProductDto>(), res.TotalItems);
            return new GridData<ProductDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(Guid id)
        {
            await _unit.Products.DeleteAsync(id);
            await _dataGrid.ReloadServerData();
        }
        private string? GetNewIcon(bool isnew)
        {
            if (isnew)
                return Icons.Material.Filled.NewReleases;
            else
                return string.Empty;
        }
        public async Task Sync()
        {
            try
            {
                ICollection<ProductEntity> dbEntities = await _unit.Products.GetAllForSync();
                
                foreach (ProductEntity dbEntity in dbEntities)
                {
                    dbEntity.ClearRelations();
                    await _restUnit.Products.WriteSync(dbEntity);
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
