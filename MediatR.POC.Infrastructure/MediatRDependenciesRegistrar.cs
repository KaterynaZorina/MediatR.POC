using MediatR.POC.Core.Shared;
using MediatR.POC.Core.Strategies.Notifications;
using MediatR.POC.Core.Strategies.Requests;
using MediatR.POC.Infrastructure.Strategies;
using MediatR.POC.Infrastructure.Strategies.Notifications;
using MediatR.POC.Infrastructure.Strategies.Notifications.Handlers;
using MediatR.POC.Infrastructure.Strategies.Notifications.Messages;
using MediatR.POC.Infrastructure.Strategies.Requests;
using MediatR.POC.Infrastructure.Strategies.Requests.Handlers;
using MediatR.POC.Infrastructure.Strategies.Requests.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR.POC.Infrastructure
{
    public static class MediatRDependenciesRegistrar
    {
        public static IServiceCollection RegisterMediatRHandlers(this IServiceCollection services)
        {
            // Registering MediatR implementation
            services.AddTransient<IDomainMediator, MediatRWrapper>();
            
            // Registering notifications & handlers
            services
                .AddTransient<IDomainNotificationHandler<UserRegisteredNotification>,
                    UserRegisteredNotificationHandler>();
            services.AddTransient<INotificationHandler<NotificationWrapper<UserRegisteredNotification>>, 
                NotificationHandlerWrapper<NotificationWrapper<UserRegisteredNotification>, UserRegisteredNotification>>();
            
            // Registering requests & handlers
            services.AddTransient<IDomainRequestHandler<SendEmailRequest, string>, SendEmailRequestHandler>();
            services.AddTransient<IRequestHandler<RequestWrapper<SendEmailRequest, string>, string>, 
                RequestHandlerWrapper<RequestWrapper<SendEmailRequest, string>, SendEmailRequest, string>>();
            
            return services;
        }
    }
}