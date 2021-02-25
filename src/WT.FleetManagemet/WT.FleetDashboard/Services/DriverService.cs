using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WT.FleetDashboard.DTOs;

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
        public Task<IEnumerable<Driver>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Driver driver)
        {
            await _Collection.InsertOneAsync(driver);
        }
    }
}
