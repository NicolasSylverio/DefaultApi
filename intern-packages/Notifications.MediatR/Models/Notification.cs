using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.MediatR.Models
{
    public class Notification
    {
        public string Key { get; }
        public string Message { get; }
        public object[] Args { get; }
        public NotificationType Type { get; }

        public Notification(string key, NotificationType type, params object[] args)
        {
            Key = key;
            Type = type;
            Args = args;
        }
        public Notification(string key, string message, NotificationType type)
        {
            Key = key;
            Message = message;
            Type = type;
        }
    }
}
