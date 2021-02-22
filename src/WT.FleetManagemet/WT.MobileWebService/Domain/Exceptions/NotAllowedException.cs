namespace WT.MobileWebService.Domain.Exceptions
{
    public class NotAllowedException:CustomException
    {
        private const string MessageTemplate = "Not allowed to perform '{0}' on this Entity  '{1}' because it is '{2}'";

        public string EntityName { get; }

        public string Action { get; }
        public string Reason { get; }


        public NotAllowedException(string entityName, string action,string reason, string detail = null)
            : base(string.Format(MessageTemplate, entityName,reason, action), detail)
        {
            EntityName = entityName;
            Action = action;
            Reason = reason;
        }
    }
}
