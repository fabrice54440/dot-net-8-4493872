using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P2p;

class Program
{
    // dotnet run 127.0.0.1:2001 127.0.0.1:2002 127.0.0.1:2003
    // dotnet run 127.0.0.1:2002 127.0.0.1:2001 127.0.0.1:2003
    // dotnet run 127.0.0.1:2003 127.0.0.1:2001 127.0.0.1:2002
    static void Main(string[] args)
    {
        // Arguments
        if (args.Length < 2)
        {
            Console.Error.WriteLine("Usage : com_06 adresse autre1 [autre2]");
            return;
        }
        var adresses = args.Select(adr => IPEndPoint.Parse(adr));

        // Réception
        using CancellationTokenSource source = new();
        CancellationToken jeton = source.Token;

        Task.Run(() =>
        {
            var mem = new byte[1024];
            ArraySegment<byte> buffer = new(mem);

            while (!jeton.IsCancellationRequested)
            {
                // Lecture du message (et des informations de l'émetteur)
                var msg = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(msg);
                Array.Fill<byte>(mem, 0);
            }
        }, jeton);

        // Envoi
        string msg;

        do
        {
            msg = Console.ReadLine() ?? "bye";
            foreach (var adr in adresses.Skip(1))
            {
                var octets = Encoding.UTF8.GetBytes(msg);
                // Envoi du message aux autres
            }
        }
        while (!msg.Equals("bye", StringComparison.InvariantCultureIgnoreCase));
        source.CancelAfter(1_000);
    }
}
