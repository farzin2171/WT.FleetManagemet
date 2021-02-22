using System;
using System.Linq;
using System.Threading.Tasks;
using WT.MobileWebService.Data;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Domain.Enums;
using WT.MobileWebService.Domain.Exceptions;

namespace WT.MobileWebService.Services
{
    public class DriverService : IDriverService
    {
        private readonly DataContext _dataContext;
        public DriverService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Driver> CreateAsync(Driver driver)
        {
            var existDriver = _dataContext.Drivers.FirstOrDefault(c => c.PhoneNumber == driver.PhoneNumber);
            if(existDriver !=null)
            {
                throw new EntityAlreadyExistException("Driver", "PhoneNumber");
            }
            await _dataContext.Drivers.AddAsync(driver);
            await _dataContext.SaveChangesAsync();

            return driver;
        }

        public Task<Driver> GetByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Driver> UpdateAsync(Driver driver)
        {
            if (_dataContext.Drivers.FirstOrDefault(c => c.PhoneNumber == driver.PhoneNumber) != null)
            {
                throw new EntityAlreadyExistException("Driver", "PhoneNumber");
            }
            var existDriver = _dataContext.Drivers.FirstOrDefault(c => c.Id == driver.Id);
            if (existDriver==null)
            {
                throw new EntityNotFoundException("driver", driver.Id.ToString());
            }
            existDriver.EntityStatus = EntityStatus.IsUpdated;
            existDriver.ActionDate = DateTime.UtcNow;
            existDriver.Name = driver.Name;
            existDriver.Family = driver.Family;
            existDriver.PhoneNumber = driver.PhoneNumber;

            await _dataContext.SaveChangesAsync();
            return existDriver;
        }

        public  async Task UpdateStatus(DriverStatus driverStatus,string phoneNumber)
        {
            var existDriver = _dataContext.Drivers.FirstOrDefault(c => c.PhoneNumber==phoneNumber);
            if (existDriver == null)
            {
                throw new EntityNotFoundException("driver", phoneNumber);
            }

            existDriver.DriverStatus = driverStatus;
            existDriver.EntityStatus = EntityStatus.IsUpdated;
            existDriver.ActionDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync();

        }
    }
}
