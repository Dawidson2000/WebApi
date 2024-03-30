namespace WebApi.Middlewares
{
    public class LogHeadersMiddleware(RequestDelegate next, ILogger<LogHeadersMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<LogHeadersMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            foreach (var header in context.Request.Headers)
            {
                _logger.LogInformation("Header: {Key}: {Value}", header.Key, header.Value);
            }

            await _next(context);
        }
    }
}
