using System;

namespace WT.MessageBrokers.Messages
{
    public class LocationMessage
    {
        public Guid Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime SampledDate { get; set; }
    }
}
