using System;

namespace WT.MobileWebService.Contract.V1.Requests
{
    public class CreateLocationRequest
    {
        public Guid Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime SampledDate { get; set; }
    }
}
