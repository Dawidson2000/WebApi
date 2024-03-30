namespace WebApi.Middlewares
{
    public static class UseMiddlewaresExtension
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app) 
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<LogHeadersMiddleware>();

            return app;
        }
    }
}
