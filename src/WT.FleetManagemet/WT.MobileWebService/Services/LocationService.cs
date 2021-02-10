using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT.MobileWebService.Data;
using WT.MobileWebService.Domain;

namespace WT.MobileWebService.Services
{
    public class LocationService : ILocationService
    {
        private readonly DataContext _dataContext;
        public LocationService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task CreateAsync(Location location)
        {
            await _dataContext.Locations.AddAsync(location);
            await _dataContext.SaveChangesAsync();
        }
    }
}
