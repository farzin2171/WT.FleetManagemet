using System.Threading.Tasks;
using WT.MobileWebService.Data;
using WT.MobileWebService.Domain;
using System.Linq;
using System;
using WT.MobileWebService.Domain.Exceptions;

namespace WT.MobileWebService.Services
{
    public sealed class CustomerInformationService : ICustomerInformationService
    {
        private readonly DataContext _dataContext;

        public CustomerInformationService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task CreateAsync(CustomerInformation customerInformation)
        {
            var customer = _dataContext.CustomerInformations.FirstOrDefault(c => c.Email.ToLower() == customerInformation.Email.ToLower());
            if(customer !=null)
            {
                throw new EntityAlreadyExistException("customerInformation", customerInformation.Email);
            }
            await _dataContext.CustomerInformations.AddAsync(customerInformation);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerInformation customerInformation)
        {
            var value = _dataContext.CustomerInformations.FirstOrDefault(c => c.Id == customerInformation.Id);
            value.FirstName = customerInformation.FirstName;
            value.LastName = customerInformation.LastName;

            await _dataContext.SaveChangesAsync();
        }
    }
}
