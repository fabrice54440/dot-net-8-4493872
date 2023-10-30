namespace Tableaux;

class Program
{
    static void Afficher(string[] liste, Range r)
    {
        foreach (var c in liste[r])
        {
            Console.WriteLine(c);
        }
    }

    static void Main(string[] args)
    {
        var couleurs = "rouge, orange, jaune, vert, bleu, violet".Split(", ");

        Afficher(couleurs, Range.All);
        Console.WriteLine();

        #region Boucle d'initialisation
        var couleursMaj = new string[couleurs.Length];

        for (int i = 0; i < couleurs.Length; i++)
        {
            couleursMaj[i] = couleurs[i].ToUpper();
        }
        #endregion
        Afficher(couleursMaj, Range.All);
        Console.WriteLine();

        couleurs[^1] = "Violet";
        Afficher(couleurs, ..2);
        Console.WriteLine("...");
        Afficher(couleurs, ^2..);
    }
}
