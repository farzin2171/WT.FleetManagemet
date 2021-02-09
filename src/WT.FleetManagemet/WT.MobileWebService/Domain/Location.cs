using System;

namespace WT.MobileWebService.Domain
{
    public class Location
    {
        public Location()
        {
            IsTransfered = false;
            RecivedDate = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime RecivedDate { get; set; }
        public DateTime SampledDate { get; set; }
        public bool IsTransfered { get; set; }
    }
}
