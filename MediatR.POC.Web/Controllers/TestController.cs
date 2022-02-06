using System.Threading.Tasks;
using MediatR.POC.Core.Shared;
using MediatR.POC.Infrastructure.Strategies.Notifications.Messages;
using MediatR.POC.Infrastructure.Strategies.Requests.Messages;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.POC.Web.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly IDomainMediator _mediator;

        public TestController(IDomainMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("publish-notification")]
        public async Task<IActionResult> PublishNotification()
        {
            var userNotification = new UserRegisteredNotification("Smth");
            await _mediator.Publish(userNotification);
            
            return Ok("Published");
        }
        
        [HttpGet("send-request")]
        public async Task<IActionResult> SendRequest()
        {
            var emailRequest = new SendEmailRequest("test@test.com");
            var userEmail = await _mediator.Send<SendEmailRequest, string>(emailRequest);
            
            return Ok(userEmail);
        }
    }
}