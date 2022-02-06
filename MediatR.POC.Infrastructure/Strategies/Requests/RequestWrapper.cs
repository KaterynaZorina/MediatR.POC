namespace MediatR.POC.Infrastructure.Strategies.Requests
{
    public class RequestWrapper<TRequest, TResponse>: IRequest<TResponse>
    {
        public TRequest Request { get; set; }

        public RequestWrapper(TRequest request)
        {
            Request = request;
        }
    }
}