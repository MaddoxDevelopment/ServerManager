using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ServerManager.Pipeline
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly TelemetryClient _client;
			
		public ExceptionMiddleware(RequestDelegate next, TelemetryClient client)
		{
			_next = next;
			_client = client;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			_client.TrackException(exception);
			
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
			
			var error = exception.Message;
			
			return context.Response.WriteAsync(JsonConvert.SerializeObject(new
			{
				error
			}));
		}
	}
}