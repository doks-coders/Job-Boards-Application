using JobBoardsSite.Shared.Models;
using System.Text.Json;

namespace JobBoardsSite.Api.Middleware
{
	public class ErrorMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ErrorMiddleware> _logger;
		private readonly IHostEnvironment _env;

		public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger, IHostEnvironment env)
		{
			_next = next;
			_logger = logger;
			_env = env;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}catch(Exception ex)
			{
			
				var errorModal = new ErrorResponseModal(ex.Message, ex.Message, ex.StackTrace??"Internal Server Error");

				context.Response.ContentType = "application/json";
				context.Response.StatusCode = int.Parse(errorModal.StatusCode);


				var json = JsonSerializer.Serialize(errorModal);

				await context.Response.WriteAsync(json);
			}
		}
	}
}
