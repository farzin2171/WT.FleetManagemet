using Microsoft.Extensions.Logging;
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
        private readonly ILogger<LocationServiceSendMessage> _logger;
        public LocationServiceSendMessage(ILocationService locationService, ILogger<LocationServiceSendMessage> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }
        public async Task CreateAsync(Location location)
        {
            //var (messageBrokerPublisher, messageBrokerSubscriber) = MessageBrokerFactory.Create(MessageBrokerType.RabbitMq);
            //_logger.LogError("Eroro from ");
            //try
            //{
               
            //    var message = JsonSerializer.Serialize(location);
            //    var body = Encoding.UTF8.GetBytes(message);
            //    await messageBrokerPublisher.Publish(new Message(body,
            //                                             Guid.NewGuid().ToString("N"),
            //                                             "application/json",
            //                                             "MobileWebServices",
            //                                             "corr_" + Guid.NewGuid().ToString("N")));

            //}
            //catch(Exception exp)
            //{
            //    var x = exp;
            //}
            //finally
            //{
            //    messageBrokerPublisher.Dispose();
            //    messageBrokerSubscriber.Dispose();
            //}
            //await  _locationService.CreateAsync(location);


        }
    }
}
