using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.POC.Core.Strategies.Notifications;
using MediatR.POC.Infrastructure.Strategies.Notifications.Messages;

namespace MediatR.POC.Infrastructure.Strategies.Notifications.Handlers
{
    public class UserRegisteredNotificationHandler: IDomainNotificationHandler<UserRegisteredNotification>
    {
        public Task Handle(UserRegisteredNotification notification, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("UserRegisteredNotification was handled");
            
            return Task.CompletedTask;
        }
    }
}