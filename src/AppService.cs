using Microsoft.Extensions.Hosting;

namespace App;

class AppService : BackgroundService
{
  public string Message { get; init; }

  public AppService(string msg) => Message = msg;

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      Console.WriteLine(Message);
      try
      {
        await Task.Delay(500);
      }
      catch (OperationCanceledException)
      {
        break;
      }
    }
  }
}
