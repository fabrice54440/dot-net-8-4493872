using System.IO;
using System.Text;

namespace Chiffrement;

class Program
{
    static void Main(string[] args)
    {
        // Symétrique
        using (FileStream f = new("obj/fichier.sec", FileMode.Create))
        using (StreamWriter writer = new(f))
        {
            writer.WriteLine("Le roi est nu");
        }

        using (FileStream f = new("obj/fichier.sec", FileMode.Open))
        using (StreamReader reader = new(f))
        {
            Console.WriteLine(reader.ReadToEnd());
        }

        // Asymétrique
        var message = Encoding.ASCII.GetBytes("Le roi est nu");

        Console.WriteLine(Encoding.ASCII.GetString(message));
    }
}
