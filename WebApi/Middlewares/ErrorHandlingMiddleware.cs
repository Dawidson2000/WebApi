
namespace WebApi.Middlewares
{
    public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<LogHeadersMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<LogHeadersMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
