using Refit;
using System;
using System.Threading.Tasks;
using WT.MobileWebService.Contract.V1.Requests;

namespace WT.FleetManagement.Sdk.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cachedToken = string.Empty;
            var apiUri = "https://localhost:5001";
            var identityApi = RestService.For<IIdentityApi>(apiUri);
            var locationApi = RestService.For<ILocationsApi>(apiUri,new RefitSettings
            {
                AuthorizationHeaderValueGetter=()=>Task.FromResult(cachedToken)
            });


            var loginResponse = await identityApi.LoginAsync(new UserLoginRequest
            {
                Email = "sdkAccount@gmail.com",
                Password = "Test1234!"
            });

            cachedToken = loginResponse.Content.Token;

            var createLocation = await locationApi.CreateAsync(new CreateLocationRequest
            {
                Id = Guid.NewGuid(),
                Lat = 22,
                Lon = 23,
                SampledDate = DateTime.Now
            });

        }
    }
}
