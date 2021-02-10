using System.Threading.Tasks;
using WT.MobileWebService.Domain;

namespace WT.MobileWebService
{
    public interface ILocationService
    {
        Task CreateAsync(Location location);
    }
}
