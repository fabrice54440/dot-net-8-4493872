using Microsoft.Extensions.Hosting;

namespace App;

class AppService : BackgroundService
{
  private IMessageProvider MsgService { get; init; }
  public AppService(IMessageProvider msg)
  {
    MsgService = msg;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      Console.WriteLine(MsgService.NextMessage);
      try
      {
        await Task.Delay(100);
      }
      catch (OperationCanceledException)
      {
        break;
      }
    }
  }
}
