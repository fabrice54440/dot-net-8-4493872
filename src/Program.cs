namespace ExpReg;

class Program
{
    static void Main(string[] args)
    {
        var bic = "ATCICIAB";

        Console.Write($"Le BIC '{bic}' est ");
        if (bic is not null) // TODO : [A-Z]{6}[A-Z0-9]{2,5}
        {
            Console.WriteLine("valide.");
        }
        else
        {
            Console.WriteLine("non valide.");
        }

        var twitGeorgeSand = "Tu fuyais la #solitude et la trouvait #partout.";

        var hashtags = Array.Empty<string>(); // TODO : Extraire #\w+

        foreach (var tag in hashtags)
        {
            Console.WriteLine(tag);
        }

        var html = twitGeorgeSand;

        Console.WriteLine(html);
    }
}
