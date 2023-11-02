using System.Collections.Generic;
using System.Net;

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
        Console.WriteLine("Hello World!");
    }
}
