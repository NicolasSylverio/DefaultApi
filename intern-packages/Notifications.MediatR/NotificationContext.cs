using FluentValidation.Results;
using Notifications.MediatR.Interfaces;
using Notifications.MediatR.Models;

namespace Notifications.MediatR
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<Notification> _notifications;
        private IReadOnlyCollection<Notification> Notifications => _notifications;

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="failures">Fluent Validator Failures</param>
        public void AddFluentValidationNotification(IEnumerable<ValidationFailure> failures)
        {
            foreach (var failure in failures)
            {
                _notifications.Add(new Notification(failure.ErrorCode, failure.ErrorMessage, NotificationType.NotificationBadRequest));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        public void AddNotification(string key, string message, NotificationType type, params object[] parameters)
            => _notifications.Add(new Notification(key, string.Format(message, parameters), type));

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Notification> GetNotifications() => Notifications;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HasNotifications() => _notifications.Any();
    }
}