using MediatR.POC.Core.Strategies.Notifications.Messages;

namespace MediatR.POC.Infrastructure.Strategies.Notifications.Messages
{
    public class UserRegisteredNotification: IDomainNotification
    {
        public UserRegisteredNotification(string userName) => UserName = userName;

        public string UserName { get; set; }
    }
}