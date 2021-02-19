using System;

namespace WT.FleetDashboard.DTOs
{
    public class EventMessage
    {
        public string Id { get; }
        public string Body { get; }
        public DateTime CreatedDateTime { get; }

        public EventMessage(string id, string body, DateTime createdDateTime)
        {
            Id = id;
            Body = body;
            CreatedDateTime = createdDateTime;
        }
    }
}
