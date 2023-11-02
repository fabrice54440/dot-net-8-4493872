using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;

namespace App;

class AppService : BackgroundService
{
  private IMessageProvider MsgService { get; init; }
  private Histogram<double> statLoop;
  public AppService(IMessageProvider msg, Meter meter)
  {
    MsgService = msg;
    statLoop = meter.CreateHistogram<double>("ExecuteAsync loop", "ms");
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    Stopwatch chrono = new();

    while (!stoppingToken.IsCancellationRequested)
    {
      chrono.Start();
      Console.WriteLine(MsgService.NextMessage);
      try
      {
        await Task.Delay(100);
      }
      catch (OperationCanceledException)
      {
        break;
      }
      finally
      {
        chrono.Stop();
        statLoop.Record(chrono.Elapsed.TotalMilliseconds);
      }
    }
  }
}
