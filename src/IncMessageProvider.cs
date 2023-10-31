using Microsoft.Extensions.Configuration;

namespace App;

public class IncMessageService : IMessageProvider
{
  private int inc = 0;
  private string Prefix { get; init; }
  public IncMessageService(IConfiguration conf)
      => Prefix = conf.GetValue("options:msg", "ok") ?? "ok";

  public string NextMessage => $"{Prefix} ({++inc})";
}