using System.Diagnostics;

namespace Hospital_Managemnet_System.Middleware
{
    public class RequestLoggingMiddleware
    {
        // Reference to the next middleware in the pipeline
        private readonly RequestDelegate _next;

        // Built-in ASP.NET Core logger
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        // RequestLoggingMiddleware constructor
        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // InvokeAsync middleware method
        public async Task InvokeAsync(HttpContext context)
        {
            // Start measuring request execution time
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Pass the request to the next middleware/component
                await _next(context);
            }
            finally
            {
                // Stop the timer after the request has completed
                stopwatch.Stop();

                // Log request details
                _logger.LogInformation(
                    "Method: {Method} | Path: {Path} | StatusCode: {StatusCode} | ResponseTime: {ResponseTime} ms",

                    // HTTP Method (GET, POST, PUT, DELETE, etc.)
                    context.Request.Method,

                    // Requested endpoint path
                    context.Request.Path,

                    // Response status code (200, 201, 400, 500, etc.)
                    context.Response.StatusCode,

                    // Total execution time in milliseconds
                    stopwatch.ElapsedMilliseconds);
            }
        }

    }
}
