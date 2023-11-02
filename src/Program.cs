using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        using Socket udp = new Socket(SocketType.Dgram, ProtocolType.Udp);

        udp.Bind(new IPEndPoint(IPAddress.Any, adresses.First().Port));

        // Réception
        using CancellationTokenSource source = new();
        CancellationToken jeton = source.Token;

        Task.Run(async () =>
        {
            EndPoint quiconque = new IPEndPoint(IPAddress.Any, 0);
            var mem = new byte[1024];
            ArraySegment<byte> buffer = new(mem);

            while (!jeton.IsCancellationRequested)
            {
                var res = await udp.ReceiveFromAsync(buffer, SocketFlags.None, quiconque, jeton);
                var msg = Encoding.UTF8.GetString(buffer);

                Console.WriteLine($"{res.RemoteEndPoint} : {msg}");
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
                udp.SendTo(octets, octets.Length, SocketFlags.None, adr);
            }
        }
        while (!msg.Equals("bye", StringComparison.InvariantCultureIgnoreCase));
        source.CancelAfter(1_000);
    }
}
