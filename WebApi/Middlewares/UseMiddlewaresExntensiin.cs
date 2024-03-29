namespace WebApi.Middlewares
{
    public static class UseMiddlewaresExntensiin
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app) 
        {
            app.UseMiddleware<LogHeadersMiddleware>();

            return app;
        }
    }
}
