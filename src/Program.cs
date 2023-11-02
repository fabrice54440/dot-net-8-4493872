using System.IO;
using System.Text;

namespace LireEcrire;

class Program
{
    static void Main(string[] args)
    {
        var prénom = "Sylvain";
        var nom = "LABASSE";
        var valeur1 = 5;
        var valeur2 = 3.2;

        try
        {
            using FileStream flux0 = new(
                "exemple.dat",
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.None
            );
            using BufferedStream flux1 = new(flux0);
            using BinaryWriter writer = new(flux1);

            writer.Write(Encoding.ASCII.GetBytes(prénom.PadRight(50)));
            writer.Write(Encoding.ASCII.GetBytes(nom.PadRight(50)));
            writer.Write(valeur1);
            writer.Write(valeur2);
            writer.Seek(50, SeekOrigin.Begin);
            writer.Write(Encoding.ASCII.GetBytes("-------".PadRight(50)));

            flux1.Close();
        }
        catch (IOException e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }
}
