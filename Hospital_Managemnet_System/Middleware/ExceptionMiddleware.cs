using Microsoft.Data.SqlClient;

namespace Hospital_Management_Web_Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next; 

        // ExceptionMiddleware constructor
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // InvokeAsync middleware method for exception handling
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (SqlException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    Message = ex.Message
                });
            }
            catch (Exception)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "An unexpected error occurred."
                });
            }
        }
    }
}