using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace Reseau;

class Program
{
    public static void AfficherAdresses(string titre, IEnumerable<IPAddress> adresses)
    {
        Console.WriteLine(titre);
        foreach (var adr in adresses)
        {
            Console.WriteLine($"\t- {adr}");
        }
    }
    static void Main(string[] args)
    {
        if (!NetworkInterface.GetIsNetworkAvailable())
        {
            Console.WriteLine("Oups ! Pas d'accès Internet");
        }
        foreach (var it in NetworkInterface.GetAllNetworkInterfaces())
        {
            Console.WriteLine($"Interface {it.Name} :");
            if (it.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            {
                var p = it.GetIPProperties();

                AfficherAdresses("- Passerelles", p.GatewayAddresses.Select(adr => adr.Address));
                AfficherAdresses("- DNS", p.DnsAddresses);
                AfficherAdresses("- DHCP", p.DhcpServerAddresses);
                AfficherAdresses("- WINS", p.WinsServersAddresses);
            }
        }
        var dest = "8.8.8.8";
        var destIP = IPAddress.Parse(dest);
        var nom = Dns.GetHostEntry(destIP);
        Ping ping = new();

        Console.WriteLine($"Ping {dest} ({nom.HostName}) :");
        for (var i = 0; i < 5; i++)
        {
            var réponse = ping.Send(destIP, TimeSpan.FromSeconds(1.0), null, null);

            Console.WriteLine($"{réponse.Status,-20} {réponse.RoundtripTime,10} ms");
            Thread.Sleep(1_000);
        }
    }
}
