# Playing with Metrics

This small application is a silly example to try out [app-metrics](https://www.app-metrics.io/) for .NET Core with [Prometheus](https://prometheus.io/) and [InfluxDB](https://www.influxdata.com/).

You can use Prometheus and InluxDB with [Grafana](https://grafana.com/) to get a cool visualization.

#### Resources
- [ASP.NET Core App: Metrics](https://owldrivendevelopment.net/2019/11/02/asp-net-core-app-metrics) *(Rival Abdrakhmanov)*
- Metrics Reporters: [Prometheus](https://www.app-metrics.io/reporting/reporters/prometheus/), [InfluxDB](https://www.app-metrics.io/reporting/reporters/influx-data/)
- [Reporting Metrics To Prometheus In ASP.NET Core](https://www.c-sharpcorner.com/article/reporting-metrics-to-prometheus-in-asp-net-core) *(C# Corner)*

#### Prometheus
- [Download](https://prometheus.io/download/) for test purpose in Windows.
- Scrape config: in prometheus.yml
- Run: prometheus.exe | http://localhost:9090