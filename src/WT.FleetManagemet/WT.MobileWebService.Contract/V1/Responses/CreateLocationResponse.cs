using System;

namespace WT.MobileWebService.Contract.V1.Responses
{
    public class CreateLocationResponse
    {
        public Guid Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime SampledDate { get; set; }
    }
}
