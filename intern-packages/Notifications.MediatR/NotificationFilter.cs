using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Notifications.MediatR.Interfaces;
using Notifications.MediatR.Models;

namespace Notifications.MediatR
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotificationContext _notificationContext;
        private const string ContentType = "application/json";

        public NotificationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync
        (
            ResultExecutingContext context,
            ResultExecutionDelegate next
        )
        {
            if (!_notificationContext.HasNotifications())
                await next();

            var notifications = _notificationContext.GetNotifications();
            var notificationType = notifications.First().Type;

            context.HttpContext.Response.StatusCode = (int)notificationType;
            context.HttpContext.Response.ContentType = ContentType;

            var resultObject = JsonConvert.SerializeObject(Result<object>.Failure(notifications.Select(x => x.Message)));

            await context.HttpContext.Response.WriteAsync(resultObject);
        }
    }
}