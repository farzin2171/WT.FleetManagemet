using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WT.FleetDashboard.Contracts;
using WT.FleetDashboard.DTOs;
using WT.FleetDashboard.Infrastructure.Hubs;
using WT.FleetDashboard.Infrastructure.MessageBroker;
using WT.FleetDashboard.Infrastructure.MessageBroker.Handlers;
using WT.FleetDashboard.Services;
using WT.MessageBrokers;


namespace WT.FleetDashboard.Infrastructure.WorkerServices
{
    public class MessageBrokerPubSubWorker : BackgroundService
    {
        private static readonly IDictionary<string, Type> ConsumableMessageTypes = new Dictionary<string, Type>
        {
            {nameof(DriverCreated), typeof(DriverCreated)},
        };
        private static readonly IDictionary<Type, Type> MessageHandlers = new Dictionary<Type, Type>
        {
            {typeof(DriverCreated), typeof(DriverCreatedHandler)},
        };

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
             //await SubescribeDrivers(stoppingToken);
            _messageBrokerSubscriber.Subscribe(messageHandler);
            while (!stoppingToken.IsCancellationRequested)
            {


                await Task.Delay(3000, stoppingToken);
            }
        }

        private async Task messageHandler(MessageReceivedEventArgs args)
        {
            var messageTypeName = args.Message.MessageType;
            if (!ConsumableMessageTypes.TryGetValue(messageTypeName.ToString() ?? string.Empty, out var messageType))
            {
                Console.WriteLine($"Message of MessageType {messageTypeName} is not consumable. Skipping.");
                return;
            }

            using (var scope = Services.CreateScope())
            {
                var handler = (IMessageHandler)ActivatorUtilities.CreateInstance(scope.ServiceProvider, MessageHandlers[messageType]);
                await handler!.HandleMessageAsync(args);
                _messageBrokerSubscriber.Acknowledge(args.AcknowledgeToken);
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
