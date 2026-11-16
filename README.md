# aspnetcore-request-trace-serilog

Ejemplo mínimo de un middleware en ASP.NET Core MVC (.NET 10) que identifica cada petición con un `Correlation-Id` y lo propaga a los logs de Serilog.

- Se devuelve en el header de respuesta `Correlation-Id`.
- Aparece en los logs como `{CorrelationId}`.

## Cómo funciona

`RequestTraceMiddleware` toma `HttpContext.TraceIdentifier`, lo escribe en el header y lo agrega al `LogContext` de Serilog. Debe registrarse **antes** de `UseSerilogRequestLogging()` para que el log de la petición también lleve el id:

```csharp
app.UseMiddlewares();
app.UseSerilogRequestLogging();
```

La plantilla de log está en `appsettings.json`:

```
[{Timestamp:HH:mm:ss} {Level:u3}] [{MachineName}|{ThreadId}] [{CorrelationId}] {Message:lj}
```
