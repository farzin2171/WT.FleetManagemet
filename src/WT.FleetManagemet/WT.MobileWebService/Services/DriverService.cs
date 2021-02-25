using System;
using System.Collections.Generic;
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

        public IEnumerable<Driver> GetInserted(int limit)
        {
            return _dataContext.Drivers.Where(c => c.EntityStatus == EntityStatus.IsNew).OrderBy(c => c.ActionDate).Take(limit);
        }

        public IEnumerable<Driver> GetUpdated(int limit)
        {
            return _dataContext.Drivers.Where(c => c.EntityStatus == EntityStatus.IsUpdated).OrderBy(c=>c.ActionDate).Take(limit);
        }

        public async Task SetIstransfered(Guid id)
        {
            var existDriver = _dataContext.Drivers.FirstOrDefault(c => c.Id == id);
            if (existDriver == null)
            {
                throw new EntityNotFoundException("driver", id.ToString());
            }
            existDriver.EntityStatus = EntityStatus.IsUpdated;
            existDriver.ActionDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync();
        }

        public async Task<Driver> UpdateAsync(Driver driver)
        {
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



        public  async Task UpdateStatus(string driverStatus,string phoneNumber)
        {
            var existDriver = _dataContext.Drivers.FirstOrDefault(c => c.PhoneNumber==phoneNumber);
            if (existDriver == null)
            {
                throw new EntityNotFoundException("driver", phoneNumber);
            }
            Enum.TryParse(driverStatus, out DriverStatus enumDriverStatus);
            
            existDriver.DriverStatus = enumDriverStatus;
            existDriver.EntityStatus = EntityStatus.IsUpdated;
            existDriver.ActionDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync();

        }
    }
}
