using System;
using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters;
using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PlayingWithMetrics
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      //createHostBuilderWithPrometheus(args).Build().Run();
      createHostBuilderWithInfluxDb(args).Build().Run();
    }

    private static IHostBuilder createHostBuilderWithPrometheus(string[] args)
    {
      IMetricsRoot metrics = AppMetrics
        .CreateDefaultBuilder()
        .OutputMetrics.AsPrometheusPlainText()
        .OutputMetrics.AsPrometheusProtobuf()
        .Build();

      // http://localhost:5000/metrics-text
      // http://localhost:5000/metrics

      return Host
        .CreateDefaultBuilder(args)
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
        .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>());
    }

    private static IHostBuilder createHostBuilderWithInfluxDb(string[] args)
    {
      IMetricsRoot metrics = AppMetrics
        .CreateDefaultBuilder()
        .Report.ToInfluxDb(option =>
        {
          option.InfluxDb.BaseUri  = new Uri("http://localhost:8086");
          option.InfluxDb.Database = "my-metrics";
          option.InfluxDb.CreateDataBaseIfNotExists = true;
        })
        .Build();

      return Host
        .CreateDefaultBuilder(args)
        .ConfigureMetrics(metrics)
        .UseMetricsWebTracking()
        .UseMetrics()
        .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>());
    }
  }
}
