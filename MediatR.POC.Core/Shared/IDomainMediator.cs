using System.Threading;
using System.Threading.Tasks;
using MediatR.POC.Core.Strategies.Notifications.Messages;
using MediatR.POC.Core.Strategies.Requests.Messages;

namespace MediatR.POC.Core.Shared
{
    public interface IDomainMediator
    {
        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : IDomainNotification;

        Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IDomainRequest;

        Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IDomainRequest<TResponse>;
    }
}