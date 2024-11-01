using CafeApp.Domain.Interfaces;
using MudBlazor;

namespace CafeApp.Shared.Util
{
    internal class NotificationService : INotification
    {
        private readonly ISnackbar _snakbar;

        public NotificationService(ISnackbar snakbar)
        {
            _snakbar = snakbar;
        }

        public void Error(string message)
        {
        }

        public void NotifySuccess()
        {
            _snakbar.Add(StaticMessages.Success, Severity.Success);
        }
    }
}
