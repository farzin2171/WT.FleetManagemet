using Refit;
using System.Threading.Tasks;
using WT.MobileWebService.Contract.V1.Requests;
using WT.MobileWebService.Contract.V1.Responses;

namespace WT.FleetManagement.Sdk
{
    [Headers("Authorization: Bearer")]
    public interface ILocationsApi
    {
        [Post("/api/v1/locations")]
        Task<ApiResponse<CreateLocationResponse>> CreateAsync([Body] CreateLocationRequest  createLocationRequest);

    }
}
