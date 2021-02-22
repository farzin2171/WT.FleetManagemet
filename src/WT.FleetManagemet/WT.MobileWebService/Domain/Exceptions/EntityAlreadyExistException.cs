namespace WT.MobileWebService.Domain.Exceptions
{
    public class EntityAlreadyExistException: CustomException
    {
        private const string MessageTemplate = "Entity '{0}' with tihs value  '{1}' already excists'";

        public string EntityName { get; }
        public string Value { get; }


        public EntityAlreadyExistException(string entityName, string value, string detail = null)
            : base(string.Format(MessageTemplate, entityName, value), detail)
        {
            EntityName = entityName;
            Value = value;
        }
    }
}
