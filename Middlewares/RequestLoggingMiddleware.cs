namespace asp.net_core_8._0_web_api.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Start timing
        var startTime = DateTime.Now;
        var requestPath = context.Request.Path;
        var requestMethod = context.Request.Method;

        try
        {
            await _next(context);
        }
        finally
        {
            // Calculate duration
            var duration = DateTime.Now - startTime;
            var statusCode = context.Response.StatusCode;

            _logger.LogInformation(
                "Request: {Method} {Path} | Status: {StatusCode} | Duration: {Duration}ms",
                requestMethod, requestPath, statusCode, duration.TotalMilliseconds
            );
        }
    }
}