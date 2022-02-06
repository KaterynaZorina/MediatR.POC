namespace MediatR.POC.Infrastructure.Strategies.Notifications
{
    public class NotificationWrapper<T> : INotification
    {
        public T Notification { get; }

        public NotificationWrapper(T notification)
        {
            Notification = notification;
        }
    }
}