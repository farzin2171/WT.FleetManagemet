using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Serilog;
using WT.MobileWebService.Domain.Exceptions;
using WT.MobileWebService.Infrastructure.Http;

namespace WT.MobileWebService.Infrastructure.MiddleWares
{
	public class CustomExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IWebHostEnvironment _hostingEnvironment;

		private const string InternalServerErrorMessage = "An unexpected error occurred!";
		private const string InternalServerErrorDetail = "Please contact the WebTech product team.";

		public CustomExceptionMiddleware(RequestDelegate next, IWebHostEnvironment hostingEnvironment)
		{
			_next = next ?? throw new ArgumentNullException(nameof(next));
			_hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (EntityNotFoundException ex)
			{
				LogForErrorContext(httpContext)
					.ForContext("EntityName", ex.EntityName)
					.ForContext("EntityId", ex.EntityId)
					.Error(ex, ex.Message);
				await httpContext.Response.WriteNotFoundResponseAsync(ex.Message, ex.Detail);
			}
			catch (CustomException ex)
			{
				LogForErrorContext(httpContext).Error(ex, ex.Message);
				await httpContext.Response.WriteBadRequestResponseAsync(ex.Message, ex.Detail);
			}
			catch (Exception ex)
			{
				LogForErrorContext(httpContext).Error(ex, ex.Message);
				await httpContext.Response.WriteInternalServerErrorResponseAsync(InternalServerErrorMessage,
					_hostingEnvironment.IsProduction() ? InternalServerErrorDetail : ex.Message);
			}
		}

		private static ILogger LogForErrorContext(HttpContext httpContext)
		{
			var request = httpContext.Request;

			var result = Log
				.ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
				.ForContext("RequestHost", request.Host)
				.ForContext("RequestProtocol", request.Protocol);

			if (request.HasFormContentType)
				result = result.ForContext("RequestForm", request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));

			return result;
		}
	}
}
