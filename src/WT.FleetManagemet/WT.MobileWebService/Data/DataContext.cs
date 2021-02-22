using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WT.MobileWebService.Domain;

namespace WT.MobileWebService.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CustomerInformation> CustomerInformations { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<DispatchOrder> DispatchOrders { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
