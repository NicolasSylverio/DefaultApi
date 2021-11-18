namespace Notifications.MediatR.Models
{
    public enum NotificationType
    {
        NotificationNoContent = 204,
        NotificationBadRequest = 400,
        NotificationNotFound = 404,
        NotificationConflict = 409,
        InternalServerError = 500
    }
}