using System.Threading.Tasks;
using WT.MobileWebService.Domain;

namespace WT.MobileWebService.Services
{
    public interface ICustomerInformationService
    {
        Task CreateAsync(CustomerInformation customerInformation);
        Task UpdateAsync(CustomerInformation customerInformation);

    }
}
