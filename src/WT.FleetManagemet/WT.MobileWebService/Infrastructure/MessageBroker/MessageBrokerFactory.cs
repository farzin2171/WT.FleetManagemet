using WT.MessageBrokers;
using WT.MessageBrokers.RabitMQ;
using WT.MobileWebService.Domain.Exceptions;

namespace WT.MobileWebService.Infrastructure.MessageBroker
{
    internal static class MessageBrokerFactory
    {
        const string brokerConnectionStringRabbitMq = "amqp://transcode_user:password@localhost/video.transcode.vhost";
        const string topicExchange = "videoreceived.exchange";
        const string queueName = "videoreceived.queue";

        public static (MessageBrokerPublisherBase messageBrokerPublisher,
                        MessageBrokerSubscriberBase messageBrokerSubscriber) Create(MessageBrokerType messageBrokerType)
        {
            switch (messageBrokerType)
            {
                case MessageBrokerType.RabbitMq:
                    return (
                       new MessageBrokerPublisherRabbitMq(brokerConnectionStringRabbitMq, topicExchange),
                       new MessageBrokerSubscriberRabbitMq(brokerConnectionStringRabbitMq, topicExchange, queueName));
            }

            throw new MessageBrokerTypeNotSupportedException(messageBrokerType.ToString());

        }
    }
}
