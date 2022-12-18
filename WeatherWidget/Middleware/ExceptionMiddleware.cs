using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace WeatherWidget.Middleware;

public class ExceptionMiddleware: IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
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
            var problem = JsonSerializer.Serialize(new
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Message = "An internal server error occurred."
            });

            await context.Response.WriteAsync(problem);
            context.Response.ContentType = MediaTypeNames.Application.Json;
        }
    }
}