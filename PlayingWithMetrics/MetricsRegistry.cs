using App.Metrics;
using App.Metrics.Counter;

namespace PlayingWithMetrics
{
  public static class MetricsRegistry
  {
    public static CounterOptions SampleCounter => new CounterOptions
    {
      Name = "Sample Counter",
      MeasurementUnit = Unit.Calls
    };

    public static CounterOptions RequestCounter => new CounterOptions
    {
      Name = "Request Counter",
      MeasurementUnit = Unit.Calls
    };
  }
}
