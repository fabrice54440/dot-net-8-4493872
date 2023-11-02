using System.Runtime.ExceptionServices;

namespace CaptEx;

class Program
{
    static void AfficherEntiers(IEnumerable<string?> valeurs)
    {
        List<Exception> errs = new();
        foreach (var val in valeurs)
        {
            try
            {
                Console.WriteLine(int.Parse(val!));
            }
            catch (Exception e)
            {
                errs.Add(e);
            }
        }
        if (errs.Count > 0)
        {
            throw new AggregateException(errs);
        }
    }
    static void GestionCentralisée(Exception e)
    {
        var infos = ExceptionDispatchInfo.Capture(e);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(e.Message);
        Console.Error.WriteLine(e.StackTrace);
        infos.Throw();
    }
    static void Main(string[] args)
    {
        string?[] valeurs = { "1024", null, "325", "toto" };

        try
        {
            AfficherEntiers(valeurs);
        }
        catch (AggregateException e)
        {
            Console.Error.WriteLine(String.Join(", ", e.InnerExceptions.Select(x => x.Message)));
        }
        try
        {
            int.Parse("toto");
        }
        catch (Exception e)
        {
            GestionCentralisée(e);
        }
    }
}