using System.Reflection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using WT.MobileWebService.Infrastructure.Logging;
using WT.MobileWebService.Options;

namespace WT.MobileWebService.Infrastructure.Extentions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureLogger(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((hostingContext, loggerConfiguration) =>
            {
                var assembly = Assembly.GetEntryAssembly();
                var version = assembly?.GetName().Version.ToString();
                var informationVersion = assembly
                    ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

                var defaultLoggerEnricherOptions = new DefaultLoggerEnricherOptions
                {
                    Application = "MobileWebService",
                    ApplicationVersion = version,
                    ApplicationInformationalVersion = informationVersion
                };

                loggerConfiguration
                    .Enrich.WithMachineName()
                    .Enrich.WithExceptionDetails()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning);

                loggerConfiguration
                    .Enrich.With(new DefaultLoggerEnricher(defaultLoggerEnricherOptions))
                    .Enrich.FromLogContext();

                if (hostingContext.HostingEnvironment.IsDevelopment())
                {
                    loggerConfiguration
                        .MinimumLevel.Debug()
                        .WriteTo.Console();
                }
                else
                {
                    loggerConfiguration
                        .MinimumLevel.Information();
                }
               
            });

            return hostBuilder;
        }
    }
}
