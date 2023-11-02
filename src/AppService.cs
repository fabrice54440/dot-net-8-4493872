using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App;

class AppService : BackgroundService
{
  private IConfiguration ConfService { get; init; }
  private IMessageProvider MsgService { get; init; }
  private ILogger<AppService> Log { get; init; }
  public AppService(IConfiguration conf, IMessageProvider msg, ILogger<AppService> log)
      => (ConfService, MsgService, Log) = (conf, msg, log);

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    Log.LogWarning($"Début {nameof(ExecuteAsync)}");
    while (!stoppingToken.IsCancellationRequested)
    {
      Console.WriteLine(MsgService.NextMessage);
      try
      {
        await Task.Delay(500);
      }
      catch (OperationCanceledException e)
      {
        Log.LogWarning(e.Message);
        break;
      }
    }
  }
}
