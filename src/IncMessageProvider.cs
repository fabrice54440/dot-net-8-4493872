using System.Diagnostics.Metrics;
using Microsoft.Extensions.Configuration;

namespace App;

public class IncMessageService : IMessageProvider
{
  private int inc = 0;
  private string Prefix { get; init; } = "Ok";
  private Counter<int> inc_metric;
  public IncMessageService(Meter meter)
  {
    inc_metric = meter.CreateCounter<int>("IncMessageService inc");
  }
  
  public string NextMessage
  {
    get
    {
      inc++;
      inc_metric.Add(1);
      return $"{Prefix} ({inc})";
    }
  }
}