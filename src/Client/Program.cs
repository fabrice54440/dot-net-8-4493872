using System.IO;
using System.Net.Sockets;

namespace Client;

// Lancement du serveur dans le terminal
// Dans src/Srv : dotnet run

// Lancement du client dans le terminal
// Dans src/Client : dotnet run
class Program
{
    static void Main(string[] args)
    {
        try
        {
            using TcpClient tcp = new();
            var cnx = tcp.ConnectAsync("localhost", 10_000);

            Console.Write("Votre message : ");
            var msg = Console.ReadLine();

            cnx.Wait();
            try
            {
                var flux = tcp.GetStream();
                using StreamWriter w = new(flux);

                w.WriteLine(msg);
                w.Flush();

                using StreamReader r = new(flux);

                while (!r.EndOfStream)
                {
                    Console.WriteLine(r.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Communication : {e.Message}");
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Connexion : {e.Message}");
        }
    }
}
