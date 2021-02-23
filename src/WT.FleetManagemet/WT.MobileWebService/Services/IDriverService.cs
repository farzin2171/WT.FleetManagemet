using System.Collections;
using System.Collections.Generic;
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
        Task UpdateStatus(string driverStatus,string phoneNumber);
        IEnumerable<Driver> GetUpdated(int limit);
        IEnumerable<Driver> GetInserted(int limit);

    }
}
