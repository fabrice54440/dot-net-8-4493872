using System.IO;

namespace Repertoires;

class Program
{
    static void Main(string[] args)
    {
        // Chemins, standard, extensions
        var dossier = Path.Combine("./bin", "sous-dossier");
        var fichier = "obj/toto.txt";
        var fichier2 = Path.ChangeExtension(fichier, ".md");

        Console.WriteLine(dossier);
        Console.WriteLine(fichier2);

        // Manipulation répertoires/fichiers
        Directory.CreateDirectory(dossier);
        var dir = new DirectoryInfo("./bin");

        // Exploration                       
        foreach (var sousDossier in dir.GetDirectories())
        {
            Console.WriteLine($"{sousDossier.FullName} {sousDossier.LastAccessTimeUtc}");
        }
    }
}
