namespace CaptEx;

class Program
{
    static void AfficherEntiers(IEnumerable<string?> valeurs)
    {
        foreach (var val in valeurs)
        {
            Console.WriteLine(int.Parse(val!));
        }
    }
    static void GestionCentralisée(Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(e.Message);
        Console.Error.WriteLine(e.StackTrace);
        throw e;
    }
    static void Main(string[] args)
    {
        string?[] valeurs = { "1024", null, "325", "toto" };

        try
        {
            AfficherEntiers(valeurs);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
        }
        try
        {
            int.Parse("123");
        }
        catch (Exception e)
        {
            GestionCentralisée(e);
        }
    }
}