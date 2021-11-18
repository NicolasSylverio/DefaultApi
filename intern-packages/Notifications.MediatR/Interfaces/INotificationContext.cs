using FluentValidation.Results;
using Notifications.MediatR.Models;

namespace Notifications.MediatR.Interfaces
{
    public interface INotificationContext
    {
        void AddNotification(string key, string message, NotificationType type, params object[] parameters);
        void AddFluentValidationNotification(IEnumerable<ValidationFailure> failures);
        IReadOnlyCollection<Notification> GetNotifications();
        bool HasNotifications();
    }
}