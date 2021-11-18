using MediatR;
using Notifications.MediatR.Models;

namespace Notifications.MediatR
{
    public class NotificationWrapper : INotification
    {
        public List<Notification> Notifications { get; private set; }

        public NotificationWrapper()
        {
            Notifications = new List<Notification>();
        }

        public NotificationWrapper(Notification notification)
        {
            Notifications = new List<Notification>
            {
                notification
            };
        }

        public void AddDomainNotification(Notification notification)
        {
            if (notification != null) Notifications.Add(notification);
        }

        public static NotificationWrapper ConflictNotification(string key)
            => new NotificationWrapper(new Notification(key, NotificationType.NotificationConflict));

        public static NotificationWrapper NotFoundNotification(string name, object id)
            => new NotificationWrapper(new Notification("NotFound", NotificationType.NotificationNotFound, name, id));

        public static NotificationWrapper InternalServerError()
            => new NotificationWrapper(new Notification("InternalServerError", NotificationType.InternalServerError));

        public static NotificationWrapper BadRequestNotification(string key, params object[] args)
            => new NotificationWrapper(new Notification(key, NotificationType.NotificationBadRequest, args));

        public static NotificationWrapper NoContent(params object[] args)
            => new NotificationWrapper(new Notification("NoContent", NotificationType.NotificationNoContent, args));
    }
}