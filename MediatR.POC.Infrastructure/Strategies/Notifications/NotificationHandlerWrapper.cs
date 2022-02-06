using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR.POC.Core.Strategies.Notifications;
using MediatR.POC.Core.Strategies.Notifications.Messages;

namespace MediatR.POC.Infrastructure.Strategies.Notifications
{
    public class NotificationHandlerWrapper<TNotificationWrapper, TDomainNotification>
        : INotificationHandler<TNotificationWrapper>
        where TNotificationWrapper: NotificationWrapper<TDomainNotification>
        where TDomainNotification: IDomainNotification
    {
        private readonly IEnumerable<IDomainNotificationHandler<TDomainNotification>> _handlers;

        public NotificationHandlerWrapper(IEnumerable<IDomainNotificationHandler<TDomainNotification>> handlers)
        {
            _handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
        }

        public Task Handle(TNotificationWrapper notification, CancellationToken cancellationToken)
        {
            var handlingTasks = _handlers.Select(h => 
                h.Handle(notification.Notification, cancellationToken));
            return Task.WhenAll(handlingTasks);
        }
    }
}