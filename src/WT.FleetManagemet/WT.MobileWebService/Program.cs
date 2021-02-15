using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT.MobileWebService.Infrastructure.Extentions;

namespace WT.MobileWebService
{
    public class Program
    {
        public static void Main(string[] args) => BuildWebHost(args).RunTasks().Run();

        public static IHost BuildWebHost(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureLogger()
                .Build();
    }
}
