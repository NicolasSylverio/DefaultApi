using Notifications.MediatR.Interfaces;

namespace Notifications.MediatR
{
    public class NotificationMessage
    {
        private readonly INotificationContext _context;

        public NotificationMessage(INotificationContext context)
        {
            _context = context;
        }

        public async Task Handle(NotificationWrapper notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                if (!notification.Notifications.Any())
                    return;

                notification.Notifications.ForEach(x =>
                {
                    _context.AddNotification(x.Key, x.Message, x.Type, x.Args);
                });
            }, cancellationToken);
        }
    }
}