namespace CafeApp.Domain.Interfaces
{
    public interface INotification
    {
        void NotifySuccess();
        void Error(string message);
    }
}
