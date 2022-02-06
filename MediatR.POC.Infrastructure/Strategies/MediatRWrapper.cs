using System.Threading;
using System.Threading.Tasks;
using MediatR.POC.Core.Shared;
using MediatR.POC.Core.Strategies.Notifications.Messages;
using MediatR.POC.Core.Strategies.Requests.Messages;
using MediatR.POC.Infrastructure.Strategies.Notifications;
using MediatR.POC.Infrastructure.Strategies.Requests;

namespace MediatR.POC.Infrastructure.Strategies
{
    public class MediatRWrapper: IDomainMediator
    {
        private readonly MediatR.IMediator _mediator;
        
        public MediatRWrapper(IMediator mediator) => _mediator = mediator;

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : IDomainNotification
        {
            var notificationWrapper = new NotificationWrapper<TNotification>(notification);
            return _mediator.Publish(notificationWrapper, cancellationToken);
        }

        public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IDomainRequest
        {
            var requestWrapper = new RequestWrapper<TRequest, Unit>(request);
            return _mediator.Send(requestWrapper, cancellationToken);
        }

        public Task<TResponse> Send<TRequest, TResponse>(TRequest request,
            CancellationToken cancellationToken = default) where TRequest : IDomainRequest<TResponse>
        {
            var requestWrapper = new RequestWrapper<TRequest, TResponse>(request);
            return _mediator.Send(requestWrapper, cancellationToken);
        }
    }
}