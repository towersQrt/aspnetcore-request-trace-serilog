namespace Urukubarr.Web.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestTraceMiddleware>();
        return app;
    }
}