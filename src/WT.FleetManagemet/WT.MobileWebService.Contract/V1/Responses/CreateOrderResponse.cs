using System;

namespace WT.MobileWebService.Contract.V1.Responses
{
    public sealed class CreateOrderResponse
    {
        public Guid Id { get; set; }
        public string OrderRef { get; set; }
    }
}
