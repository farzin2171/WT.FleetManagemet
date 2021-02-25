using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WT.FleetDashboard.DTOs;
using WT.FleetDashboard.Infrastructure.Hubs;
using WT.FleetDashboard.Infrastructure.MessageBroker;
using WT.FleetDashboard.Services;
using WT.MessageBrokers;


namespace WT.FleetDashboard.Infrastructure.WorkerServices
{
    public class MessageBrokerPubSubWorker : BackgroundService
    {
        private MessageBrokerSubscriberBase _messageBrokerSubscriber = MessageBrokerFactory.CreateSubscriber(MessageBrokerType.RabbitMq,
                                                                                                             MessageBrokerConstants.DRIVER_CREATE_EXCHANGE,
                                                                                                             MessageBrokerConstants.DRIVER_CREATE_QUENAME);
        private IHubContext<MessageBrokerHub> _hubContext;

        public IServiceProvider Services { get; }

        public MessageBrokerPubSubWorker(IHubContext<MessageBrokerHub> hubContext, IServiceProvider services)
        {
            _hubContext = hubContext;
            Services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await SubescribeDrivers(stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {


                await Task.Delay(3000, stoppingToken);
            }
        }


        private async Task SubescribeDrivers(CancellationToken cancellationToken)
        {
            _messageBrokerSubscriber.Subscribe(async message =>
            {
                var eventMessage = new EventMessage($"Id_{Guid.NewGuid():N}", Encoding.UTF8.GetString(message.Message.Body), DateTime.UtcNow);
                var driver = JsonSerializer.Deserialize<Driver>(message.Message.Body);
                using (var scope = Services.CreateScope())
                {
                    var driverService =
                        scope.ServiceProvider
                            .GetRequiredService<IDriverService>();
                    await driverService.InsertAsync(driver);


                }
                _messageBrokerSubscriber.Acknowledge(message.AcknowledgeToken);
                //await _hubContext.Clients.All.SendAsync("onMessageRecived", eventMessage);

            });

        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _messageBrokerSubscriber.Dispose();
            return Task.CompletedTask;
        }



    }
}
