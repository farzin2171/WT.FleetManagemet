using WT.MessageBrokers;
using WT.MessageBrokers.RabitMQ;
using WT.MobileWebService.Domain.Exceptions;

namespace WT.MobileWebService.Infrastructure.MessageBroker
{
    public static class MessageBrokerFactory
    {
        const string brokerConnectionStringRabbitMq = "amqp://transcode_user:password@localhost/video.transcode.vhost";

        public static MessageBrokerPublisherBase CreatePublisher(MessageBrokerType messageBrokerType,string topicExchange)
        {
            switch (messageBrokerType)
            {
                case MessageBrokerType.RabbitMq:
                    return new MessageBrokerPublisherRabbitMq(brokerConnectionStringRabbitMq, topicExchange);
                       
            }

            throw new MessageBrokerTypeNotSupportedException(messageBrokerType.ToString());

        }
        public static MessageBrokerSubscriberBase CreateSubscriber(MessageBrokerType messageBrokerType, string topicExchange, string queueName)
        {
            switch (messageBrokerType)
            {
                case MessageBrokerType.RabbitMq:
                    return new MessageBrokerSubscriberRabbitMq(brokerConnectionStringRabbitMq, topicExchange,queueName);

            }

            throw new MessageBrokerTypeNotSupportedException(messageBrokerType.ToString());

        }
    }
}
