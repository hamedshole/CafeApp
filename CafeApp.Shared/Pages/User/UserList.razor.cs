using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using MudBlazor;
namespace CafeApp.Shared.Pages.User
{
    public partial class UserList
    {
        private readonly string _route = "users";
        private async Task<GridData<UserDto>> LoadData(GridState<UserDto> gridState)
        {
            ListUserParameter parameter = new ListUserParameter();
            parameter.PageSize = gridState.PageSize;
            parameter.Page = gridState.Page + 1;
            var res = await _unit.Users.GetPaged(parameter.GetSpecifications(), parameter);
            if (res.Items is null)
                res = new PagedList<UserDto>(new List<UserDto>(), res.TotalItems);
            return new GridData<UserDto> { Items = res.Items, TotalItems = res.TotalItems };
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
            await _unit.Tables.DeleteAsync(id);
        }
        public async Task Sync()
        {
            try
            {
                ICollection<UserEntity> dbEntities = await _unit.Users.GetAllForSync();
                foreach (UserEntity dbEntity in dbEntities)
                {
                    await _restUnit.Users.WriteSync(dbEntity);
                }
                await _restUnit.Users.Apply();
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }

}
