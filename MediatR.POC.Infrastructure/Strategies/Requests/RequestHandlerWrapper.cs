using System.Threading;
using System.Threading.Tasks;
using MediatR.POC.Core.Strategies.Requests;
using MediatR.POC.Core.Strategies.Requests.Messages;

namespace MediatR.POC.Infrastructure.Strategies.Requests
{
    public class RequestHandlerWrapper<TRequestWrapper, TDomainRequest, TDomainResponse>
        : IRequestHandler<TRequestWrapper, TDomainResponse>
    where TRequestWrapper: RequestWrapper<TDomainRequest, TDomainResponse>
    where TDomainRequest: IDomainRequest<TDomainResponse>
    {
        private readonly IDomainRequestHandler<TDomainRequest, TDomainResponse> _handler;

        public RequestHandlerWrapper(IDomainRequestHandler<TDomainRequest, TDomainResponse> handler) => _handler = handler;

        public Task<TDomainResponse> Handle(TRequestWrapper request, CancellationToken cancellationToken)
        {
            return _handler.Handle(request.Request, cancellationToken);
        }
    }
}