using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WT.MessageBrokers;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Domain.Exceptions;
using WT.MobileWebService.Infrastructure.MessageBroker;

namespace WT.MobileWebService.Services
{
    public class LocationServiceSendMessage : ILocationService
    {
        private readonly ILocationService _locationService;
        public LocationServiceSendMessage(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task CreateAsync(Location location)
        {
            var (messageBrokerPublisher, messageBrokerSubscriber) = MessageBrokerFactory.Create(MessageBrokerType.RabbitMq);
            throw new EntityNotFoundException("test", "test");
            try
            {
               
                var message = JsonSerializer.Serialize(location);
                var body = Encoding.UTF8.GetBytes(message);
                await messageBrokerPublisher.Publish(new Message(body,
                                                         Guid.NewGuid().ToString("N"),
                                                         "application/json",
                                                         "MobileWebServices",
                                                         "corr_" + Guid.NewGuid().ToString("N")));

            }
            finally
            {
                messageBrokerPublisher.Dispose();
                messageBrokerSubscriber.Dispose();
            }
            await  _locationService.CreateAsync(location);


        }
    }
}
