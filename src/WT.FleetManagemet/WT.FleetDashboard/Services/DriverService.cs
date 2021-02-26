using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WT.FleetDashboard.DTOs;
using MongoDB.Driver.Linq;

namespace WT.FleetDashboard.Services
{
    public sealed class DriverService : IDriverService
    {
        private IMongoCollection<Driver> _Collection;
        public DriverService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Dashboard");
            _Collection = database.GetCollection<Driver>("Drivers");
        }
        public async Task<IEnumerable<Driver>> GetAllAsync()
        {
            return( _Collection.AsQueryable().ToList());
            
        }

        public async Task InsertAsync(Driver driver)
        {
                await _Collection.InsertOneAsync(driver);
        }
    }
}
