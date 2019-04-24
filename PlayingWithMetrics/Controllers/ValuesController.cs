using System;
using System.Collections.Generic;
using App.Metrics;
using Microsoft.AspNetCore.Mvc;

namespace PlayingWithMetrics.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly IMetrics _metrics;
    private readonly Random _random = new Random();

    public ValuesController(IMetrics metrics)
    {
      _metrics = metrics;
    }

    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      if (_random.NextDouble() < 0.35)
        throw new Exception("Just a random exception.");

      _metrics.Measure.Counter.Increment(MetricsRegistry.SampleCounter);

      return new string[] { "value1", "value2" };
    }
  }
}
