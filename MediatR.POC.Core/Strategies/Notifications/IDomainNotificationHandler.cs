using System.Threading;
using System.Threading.Tasks;
using MediatR.POC.Core.Strategies.Notifications.Messages;

namespace MediatR.POC.Core.Strategies.Notifications
{
    public interface IDomainNotificationHandler<in TNotification> 
        where TNotification: IDomainNotification
    {
        Task Handle(TNotification notification, CancellationToken cancellationToken = default);
    }
}