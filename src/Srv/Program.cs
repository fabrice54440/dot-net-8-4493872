using System.Collections.Concurrent;
using System.IO;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Srv;

class Program
{
  static void Main(string[] args)
  {
    ConcurrentBag<string> sac = new();
    TcpListener serveur = new(IPAddress.Any, 10_000);
    TaskFactory clients = new();

    serveur.Start();
    for (; ; )
    {
      var tcpClient = serveur.AcceptTcpClient();

      clients.StartNew(o => Servir((TcpClient)o!, sac), tcpClient);
    }
  }
  static async void Servir(TcpClient tcp, ConcurrentBag<string> sac)
  {
    try
    {
      using StreamReader r = new(tcp.GetStream());
      var msg = await r.ReadLineAsync();

      Console.WriteLine($"Reçu : {msg}");

      using StreamWriter w = new(tcp.GetStream());

      foreach (var txt in sac)
      {
        await w.WriteLineAsync(txt.AsMemory());
      }
      await w.FlushAsync();
      sac.Add($"{tcp.Client.RemoteEndPoint}: {msg}");
    }
    catch (Exception e)
    {
      Console.Error.WriteLine($"{tcp.Client.RemoteEndPoint}: {e.Message}");
    }
    finally
    {
      tcp.Dispose();
    }
  }
}
