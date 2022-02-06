using MediatR.POC.Core.Strategies.Requests.Messages;

namespace MediatR.POC.Infrastructure.Strategies.Requests.Messages
{
    public class SendEmailRequest: IDomainRequest<string>
    {
        public SendEmailRequest(string email) => Email = email;

        public string Email { get; set; }
    }
}