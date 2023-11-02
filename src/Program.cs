using System.IO;

namespace Compression;

class Program
{
    static void Main(string[] args)
    {
        FileInfo archive = new FileInfo("binaires.zip");

        if (archive.Exists)
        {
            archive.Delete();
        }

        // Création d'une archive

        // Ajout d'un fichier
    }
}
