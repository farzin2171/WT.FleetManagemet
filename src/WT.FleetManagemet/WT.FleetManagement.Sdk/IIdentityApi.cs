using Refit;
using System.Threading.Tasks;
using WT.MobileWebService.Contract.V1.Requests;
using WT.MobileWebService.Contract.V1.Responses;


namespace WT.FleetManagement.Sdk
{
    public interface IIdentityApi
    {
        [Post("/api/v1/identity/register")]
        Task<ApiResponse<AuthSuccessResponse>> RegiserAsync([Body] UserRegestrationRequest userRegestrationRequest);

        [Post("/api/v1/identity/login")]
        Task<ApiResponse<AuthSuccessResponse>> LoginAsync([Body] UserLoginRequest userLoginRequest);
    }
}
