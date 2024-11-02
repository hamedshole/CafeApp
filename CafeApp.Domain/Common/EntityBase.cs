namespace CafeApp.Domain.Common
{
    public interface IEntityBase
    {
        DateTime CreateTime { get; }
        Guid CreateUserId { get; }
        DateTime? DeleteTime { get; }
        Guid? DeleteUserId { get; }
        Guid Id { get; }
        bool IsDeleted { get; }
        DateTime? UpdateTime { get; }
        Guid? UpdateUserId { get; }

        void Create(Guid userId);
        void Delete(Guid userId);
        void Update(Guid userId);
    }

    public class EntityBase : IEntityBase
    {
        public Guid Id { get; private set; }
        public bool IsDeleted { get; private set; }

        public Guid CreateUserId { get; private set; }
        public DateTime CreateTime { get; private set; }
        public Guid? UpdateUserId { get; private set; }
        public DateTime? UpdateTime { get; private set; }
        public Guid? DeleteUserId { get; private set; }
        public DateTime? DeleteTime { get; private set; }

        public EntityBase()
        {

        }
        public EntityBase(Guid id)
        {
            Id = id;
        }

        public void Delete(Guid userId)
        {
            IsDeleted = true;
            DeleteUserId = userId;
            DeleteTime = DateTime.Now;
        }
        public void Create(Guid userId)
        {
            CreateUserId = userId;
            CreateTime = DateTime.Now;
        }
        public void Update(Guid userId)
        {
            UpdateUserId = userId;
            UpdateTime = DateTime.Now;
        }

    }
}
