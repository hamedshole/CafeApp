namespace CafeApp.Shared.RestClient.Interfaces
{
    public interface IBaseClient<TEntity>
    {
        public  Task<ICollection<TEntity>> SyncCategories();
        public  Task Apply();
        public Task WriteSync(TEntity entity);
    }
}
