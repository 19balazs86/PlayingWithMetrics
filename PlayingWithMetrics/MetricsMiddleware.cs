using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace PlayingWithMetrics
{
  public static class MetricsMiddlewareExtensions
  {
    public static IApplicationBuilder UseMetricsMiddleware(this IApplicationBuilder builder)
      => builder.UseMiddleware<MetricsMiddleware>();
  }

  public class MetricsMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly IMetrics _metrics;

    public MetricsMiddleware(RequestDelegate next, IMetrics metrics)
    {
      _next    = next;
      _metrics = metrics;
    }

    public async Task Invoke(HttpContext httpContext)
    {
      bool gotException = false;

      try
      {
        await _next.Invoke(httpContext);
      }
      catch (Exception)
      {
        gotException = true;

        throw;
      }
      finally
      {
        var tagsDic = new Dictionary<string, string>
        {
          ["path"]      = httpContext.Request.Path.Value,
          ["method"]    = httpContext.Request.Method,
          ["exception"] = gotException ? "1" : "0"
        };

        var tags = MetricTags.Concat(MetricTags.Empty, tagsDic);

        _metrics.Measure.Counter.Increment(MetricsRegistry.RequestCounter, tags);
      }
    }
  }
}
