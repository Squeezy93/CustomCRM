using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace CustomCRM.Api.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
		private readonly ILogger<GlobalExceptionHandler> _logger;

		public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception e)
			{
				_logger.LogError(e, e.Message);

				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				ProblemDetails problemDetails = new ProblemDetails()
				{
					Status = (int)HttpStatusCode.InternalServerError,
					Type = "Server error",
					Title = "Server error",
					Detail = e.Message
				};

				string json = JsonSerializer.Serialize(problemDetails);

				context.Response.ContentType = "application/json";

				await context.Response.WriteAsync(json);
			}
        }
    }
}
