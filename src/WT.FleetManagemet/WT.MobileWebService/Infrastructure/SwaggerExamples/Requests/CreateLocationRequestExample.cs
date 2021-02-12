using Swashbuckle.AspNetCore.Filters;
using System;
using WT.MobileWebService.Contract.V1.Requests;

namespace WT.MobileWebService.Infrastructure.SwaggerExamples.Requests
{
    public class CreateLocationRequestExample : IExamplesProvider<CreateLocationRequest>
    {
        public CreateLocationRequest GetExamples()
        {
            return new CreateLocationRequest
            {
                Id = Guid.NewGuid(),
                Lat = 44.45,
                Lon = 74.23,
                SampledDate = DateTime.Now
            };
        }
    }
}
