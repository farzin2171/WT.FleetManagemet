using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WT.MessageBrokers;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Infrastructure.MessageBroker;
using WT.MobileWebService.Services;

namespace WT.MobileWebService.Infrastructure.WorkerServices
{
    public class MessageBrokerPubSubWorker : BackgroundService
    {

        private readonly ILogger<MessageBrokerPubSubWorker> _logger;
        public IServiceProvider Services { get; }
        private MessageBrokerPublisherBase _driverPublisher = MessageBrokerFactory.CreatePublisher(MessageBrokerType.RabbitMq, MessageBrokerConstants.DRIVER_CREATE_EXCHANGE);




        public MessageBrokerPubSubWorker(ILogger<MessageBrokerPubSubWorker> logger, IServiceProvider services)
        {
            _logger = logger;
            Services = services;
            
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"MessageBrokerPubSubWorker is starting.");
            stoppingToken.Register(() =>
           _logger.LogDebug($" MessageBrokerPubSubWorker background task is stopping."));
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"MessageBrokerPubSubWorker task doing background work.");

                // This  method is querying a database table
                // and publishing events into the Event Bus (RabbitMQ / ServiceBus)
                await CheckAndPublishNewDriversAsync();

                await Task.Delay(3000, stoppingToken);

            }
        }

        private async Task CheckAndPublishNewDriversAsync()
        {

            List<Driver> updatedDrivers=new List<Driver>();
            using (var scope = Services.CreateScope())
            {
                var driverService =
                    scope.ServiceProvider
                        .GetRequiredService<IDriverService>();

                var newDrivers = driverService.GetInserted(100);
                if (!newDrivers.Any())
                {
                    return ;
                }
                foreach (var driver in newDrivers)
                {
                    var message = JsonSerializer.Serialize(driver);
                    var body = Encoding.UTF8.GetBytes(message);
                    await _driverPublisher.Publish(new Message(body,
                                                             Guid.NewGuid().ToString("N"),
                                                             "application/json",
                                                             MessageBrokerConstants.MESSAGE_TYPE_DRIVER_CREATED, 
                                                             "MobileWebServices",
                                                             "corr_" + Guid.NewGuid().ToString("N")));
                    updatedDrivers.Add(driver);
                }
                _logger.LogDebug($"CheckAndPublishNewDriversAsync found {newDrivers.Count()}.");

            }

            using (var scope = Services.CreateScope())
            {
                var driverService =
                    scope.ServiceProvider
                        .GetRequiredService<IDriverService>();

                foreach (var driver in updatedDrivers)
                {
                    await driverService.SetIstransfered(driver.Id);   
                }
            }

        }

       

    }
}
