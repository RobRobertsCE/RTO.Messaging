using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RTO.Messaging.Internal.Adapters;
using RTO.Messaging.Ports;

namespace RTO.Messaging
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRTOMessaging(this IServiceCollection services)
        {
            services.TryAddTransient<IMessageRepository, MessageRepository>();
            services.TryAddTransient<IMessageService, MessageService>();

            return services;
        }
    }
}
