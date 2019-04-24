using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters;
using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace PlayingWithMetrics
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
      IMetricsRoot metrics = AppMetrics
        .CreateDefaultBuilder()
        .OutputMetrics.AsPrometheusPlainText()
        .OutputMetrics.AsPrometheusProtobuf()
        .Build();

      // http://localhost:5000/metrics-text
      // http://localhost:5000/metrics

      return WebHost.CreateDefaultBuilder(args)
        .ConfigureMetrics(metrics)
        .UseMetricsWebTracking()
        .UseMetrics(options =>
        {
          options.EndpointOptions = endpointsOptions =>
          {
            endpointsOptions.MetricsTextEndpointOutputFormatter
              = metrics.OutputMetricsFormatters.GetType<MetricsPrometheusTextOutputFormatter>();
            //endpointsOptions.MetricsEndpointOutputFormatter
            //  = metrics.OutputMetricsFormatters.GetType<MetricsPrometheusProtobufOutputFormatter>();
          };
        })
        .UseStartup<Startup>();
    }
  }
}
