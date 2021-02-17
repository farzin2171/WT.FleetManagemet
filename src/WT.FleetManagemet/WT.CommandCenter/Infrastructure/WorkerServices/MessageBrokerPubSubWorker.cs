using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WT.CommandCenter.DTOs;
using WT.CommandCenter.Infrastructure.MessageBroker;
using WT.MessageBrokers;

namespace WT.CommandCenter.Infrastructure.WorkerServices
{
    public class MessageBrokerPubSubWorker : BackgroundService
    {
        private MessageBrokerSubscriberBase _messageBrokerSubscriber = MessageBrokerFactory.Create(MessageBrokerType.RabbitMq);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {



            }
        }

        public override  Task StartAsync(CancellationToken cancellationToken)
        {
            _messageBrokerSubscriber.Subscribe(async message =>
            {
                var eventMessage = new EventMessage($"Id_{Guid.NewGuid():N}", Encoding.UTF8.GetString(message.Message.Body), DateTime.UtcNow);
                _messageBrokerSubscriber.Acknowledge(message.AcknowledgeToken);
                
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
