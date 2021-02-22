using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WT.MobileWebService.Data;
using WT.MobileWebService.Infrastructure.Extentions;
using WT.MobileWebService.Infrastructure.StartupTasks;
using WT.MobileWebService.Services;

namespace WT.MobileWebService.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();

            services.AddStartupTask<InformationStartupTask>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ICustomerInformationService, CustomerInformationService>();
            services.AddScoped<IGenerateOrderRefrence, GenerateOrderRefrence>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDriverService, DriverService>();

            services.Decorate<ILocationService, LocationServiceSendMessage>();
        }
    }
}
