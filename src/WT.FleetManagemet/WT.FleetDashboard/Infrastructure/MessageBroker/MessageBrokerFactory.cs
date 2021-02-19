using WT.MessageBrokers;
using WT.MessageBrokers.RabitMQ;

namespace WT.FleetDashboard.Infrastructure.MessageBroker
{
    public static class MessageBrokerFactory
    {
        const string brokerConnectionStringRabbitMq = "amqp://transcode_user:password@localhost/video.transcode.vhost";
        const string topicExchange = "videoreceived.exchange";
        const string queueName = "videoreceived.queue";

        public static MessageBrokerSubscriberBase Create(MessageBrokerType messageBrokerType)
        {
            switch (messageBrokerType)
            {
                case MessageBrokerType.RabbitMq:
                    return new MessageBrokerSubscriberRabbitMq(brokerConnectionStringRabbitMq, topicExchange, queueName);

            }
            //throw new MessageBrokerTypeNotSupportedException($"The MessageBrokerType: {messageBrokerType}, is not supported yet");
            throw new System.Exception();
        }
    }
}
