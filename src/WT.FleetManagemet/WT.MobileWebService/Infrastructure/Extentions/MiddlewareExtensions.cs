using Microsoft.AspNetCore.Builder;
using WT.MobileWebService.Infrastructure.MiddleWares;

namespace WT.MobileWebService.Infrastructure.Extentions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
