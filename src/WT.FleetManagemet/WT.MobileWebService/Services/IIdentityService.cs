using System.Threading.Tasks;
using WT.MobileWebService.Domain;

namespace WT.MobileWebService.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}
