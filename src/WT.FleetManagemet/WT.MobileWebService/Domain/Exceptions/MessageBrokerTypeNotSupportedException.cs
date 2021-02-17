namespace WT.MobileWebService.Domain.Exceptions
{
    public sealed class MessageBrokerTypeNotSupportedException : CustomException
    {
        private const string MessageTemplate = "The MessageBrokerType: {0}, is not supported yet";

        public string MessageBroker { get; }
        public MessageBrokerTypeNotSupportedException(string messageBroker,string detail=""):
            base(string.Format(MessageTemplate, messageBroker), detail)
        {
            MessageBroker = messageBroker;
        }
    }
}
