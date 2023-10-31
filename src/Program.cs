using System.Text.RegularExpressions;

namespace ExpReg;

partial class Program
{
    [GeneratedRegex(@"#\w+")]
    private static partial Regex HashTagRegEx();
    static void Main(string[] args)
    {
        var bic = "ATCICIAB";

        Console.Write($"Le BIC '{bic}' est ");
        if (Regex.IsMatch(input: bic, pattern: "[A-Z]{6}[A-Z0-9]{2,5}"))
        {
            Console.WriteLine("valide.");
        }
        else
        {
            Console.WriteLine("non valide.");
        }

        var twitGeorgeSand = "Tu fuyais la #solitude et la trouvait #partout.";

        var hashtags = HashTagRegEx().Matches(twitGeorgeSand);

        foreach (var tag in hashtags)
        {
            Console.WriteLine(tag);
        }

        var html = HashTagRegEx().Replace(
          twitGeorgeSand,
          m => $"<a href='?tag={m.Value.Substring(1)}'>{m.Value}</a>"
        );

        Console.WriteLine(html);
    }
}
