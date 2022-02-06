using System.Threading;
using System.Threading.Tasks;
using MediatR.POC.Core.Strategies.Requests.Messages;

namespace MediatR.POC.Core.Strategies.Requests
{
    public interface IDomainRequestHandler<in TRequest> where TRequest: IDomainRequest
    {
        Task Handle(TRequest request, CancellationToken cancellationToken = default);
    }

    public interface IDomainRequestHandler<in TRequest, TResponse> where TRequest : IDomainRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
    }
}