using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WT.MobileWebService.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
