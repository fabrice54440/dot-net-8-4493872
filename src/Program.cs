namespace Text;

class Program
{
    static void Main(string[] args)
    {
        #region Constantes
        var fichier = @"c:\exemple.txt";
        var adresse = """
            Rue de l'Hôtel-de-Ville
            1200 Genève
            """;

        Console.WriteLine(fichier);
        Console.WriteLine(adresse);
        #endregion

        #region Mise en forme
        var prix = 9.5m;

        Console.WriteLine($"Le montant est {prix:.00} EUR.");
        #endregion

        #region Interprétation "Parsing"
        var saisie = "2.40 CHF";

        if (decimal.TryParse(saisie.Substring(0, saisie.IndexOf(' ')), out var chf))
        {
            Console.WriteLine($"Le montant lu est : {chf:.00} CHF");
        }
        else
        {
            Console.Error.WriteLine("Impossible d'extraire le montant");
        }
        #endregion

        #region Manipulation/Comparaison
        if (adresse.Contains("GENÈVE", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Adresse genevoise.");
        }
        else
        {
            Console.WriteLine("Autre ville.");
        }
        #endregion
    }
}
