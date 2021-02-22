using System.Threading.Tasks;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Domain.Enums;

namespace WT.MobileWebService.Services
{
    public  interface IDriverService
    {
        Task<Driver> GetByPhoneNumber(string phoneNumber);
        Task<Driver> CreateAsync(Driver driver);
        Task<Driver> UpdateAsync(Driver driver);
        Task UpdateStatus(DriverStatus driverStatus,string phoneNumber); 
    }
}
