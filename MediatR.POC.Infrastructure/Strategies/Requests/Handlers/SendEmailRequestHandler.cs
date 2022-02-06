using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.POC.Core.Strategies.Requests;
using MediatR.POC.Infrastructure.Strategies.Requests.Messages;

namespace MediatR.POC.Infrastructure.Strategies.Requests.Handlers
{
    public class SendEmailRequestHandler: IDomainRequestHandler<SendEmailRequest, string>
    {
        public Task<string> Handle(SendEmailRequest request, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"SendEmailRequest was received for: user with email {request.Email}");

            return Task.FromResult(request.Email);
        }
    }
}