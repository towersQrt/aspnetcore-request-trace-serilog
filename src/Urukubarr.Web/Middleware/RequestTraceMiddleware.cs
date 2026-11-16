using Serilog.Context;

namespace Urukubarr.Web.Middleware;

internal sealed class RequestTraceMiddleware
{
    private const string HeaderName = "Correlation-Id";

    private readonly RequestDelegate _next;

    public RequestTraceMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string traceId = GetCorrelationId(context);
        context.Items[HeaderName] = traceId;
        context.Response.Headers[HeaderName] = traceId;
        using (LogContext.PushProperty("CorrelationId", traceId))
        {
            await _next.Invoke(context);
        }
    }

    private static string GetCorrelationId(HttpContext context)
    {
        return context.TraceIdentifier;
    }
}
