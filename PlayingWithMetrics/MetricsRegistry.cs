using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Timer;

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

    public static TimerOptions RequestTimer => new TimerOptions
    {
      Name            = "Request Timer",
      MeasurementUnit = Unit.Requests,
      DurationUnit    = TimeUnit.Milliseconds,
      RateUnit        = TimeUnit.Milliseconds
    };
  }
}
