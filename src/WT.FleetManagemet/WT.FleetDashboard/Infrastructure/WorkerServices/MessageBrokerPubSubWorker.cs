﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WT.FleetDashboard.DTOs;
using WT.FleetDashboard.Infrastructure.Hubs;
using WT.FleetDashboard.Infrastructure.MessageBroker;
using WT.MessageBrokers;


namespace WT.FleetDashboard.Infrastructure.WorkerServices
{
    public class MessageBrokerPubSubWorker : BackgroundService
    {
        private MessageBrokerSubscriberBase _messageBrokerSubscriber = MessageBrokerFactory.Create(MessageBrokerType.RabbitMq);
        private IHubContext<MessageBrokerHub> _hubContext;

        public MessageBrokerPubSubWorker(IHubContext<MessageBrokerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {



            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _messageBrokerSubscriber.Subscribe(async message =>
            {
                var eventMessage = new EventMessage($"Id_{Guid.NewGuid():N}", Encoding.UTF8.GetString(message.Message.Body), DateTime.UtcNow);
                _messageBrokerSubscriber.Acknowledge(message.AcknowledgeToken);
                await _hubContext.Clients.All.SendAsync("onMessageRecived", eventMessage);

            });
            return Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _messageBrokerSubscriber.Dispose();
            return Task.CompletedTask;
        }



    }
}
