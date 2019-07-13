# Playing with Metrics

This small application is a silly example to try out [app-metrics](https://www.app-metrics.io/) for .NET Core with [Prometheus](https://prometheus.io/) and [InfluxDB](https://www.influxdata.com/).

You can use Prometheus and InluxDB with [Grafana](https://grafana.com/) to get a cool visualization.

#### Resources
- Metrics Reporters: [Prometheus](https://www.app-metrics.io/reporting/reporters/prometheus/), [InfluxDB](https://www.app-metrics.io/reporting/reporters/influx-data/)
- C# Corner blog: [Reporting Metrics To Prometheus In ASP.NET Core](https://www.c-sharpcorner.com/article/reporting-metrics-to-prometheus-in-asp-net-core/).

#### Prometheus
- [Download](https://prometheus.io/download/) for test purpose in Windows.
- Scrape config: in prometheus.yml
- Run: prometheus.exe | http://localhost:9090