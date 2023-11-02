using System.IO;
using System.IO.Compression;
using System.Linq;

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
        ZipFile.CreateFromDirectory("./bin", archive.FullName);

        ZipFile.ExtractToDirectory(archive.FullName, "./obj", overwriteFiles: true);

        // Ajout d'un fichier
        using (FileStream zip = new(archive.FullName, FileMode.Open))
        using (ZipArchive flux = new(zip, ZipArchiveMode.Update))
        {
            var liste = flux.Entries.ToArray();
            var index = flux.CreateEntry("index.txt");

            using (StreamWriter writer = new(index.Open()))
            {
                foreach (var fichier in liste)
                {
                    writer.WriteLine(
                        "{0} {1:0.00}%",
                        fichier.FullName,
                        (double)fichier.CompressedLength / (double)fichier.Length
                    );
                }
            }
        }
    }
}
