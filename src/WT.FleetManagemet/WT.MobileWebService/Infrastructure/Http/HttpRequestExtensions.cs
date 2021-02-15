﻿using Microsoft.AspNetCore.Http;

namespace WT.MobileWebService.Infrastructure.Http
{
	public static class HttpRequestExtensions
	{
		public static bool IsAjaxRequest(this HttpRequest request)
		{
			var query = request.Query;
			if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
			{
				return true;
			}

			var headers = request.Headers;
			return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
		}

		public static bool IsApiRequest(this HttpRequest request)
		{
			return request.Path.StartsWithSegments("/api");
		}

		public static bool IsUIRequest(this HttpRequest request)
		{
			return !IsApiRequest(request);
		}
		
	}
}
