using System.Collections.Generic;
using System.Threading.Tasks;
using WT.FleetDashboard.DTOs;

namespace WT.FleetDashboard.Services
{
    public interface IDriverService
    {
        Task InsertAsync(Driver driver);
        Task<IEnumerable<Driver>> GetAllAsync();
    }
}
