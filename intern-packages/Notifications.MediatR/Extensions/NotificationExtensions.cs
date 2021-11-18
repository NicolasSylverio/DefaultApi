using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notifications.MediatR.Interfaces;
using System.Reflection;

namespace Notifications.MediatR.Extensions
{
    public static class NotificationExtensions
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services)
        { 
            services.AddMediatR(Assembly.GetAssembly(typeof(NotificationContext)));

            services.AddScoped<INotificationContext, NotificationContext>();

            return services;
        }
    }
}