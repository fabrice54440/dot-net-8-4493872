namespace Tableaux;

class Program
{
    static void Afficher(string[] liste)
    {
        foreach (var c in liste)
        {
            Console.WriteLine(c);
        }
    }

    static void Main(string[] args)
    {
        var couleurs = new string[] {
            "rouge", "orange", "jaune", "vert", "bleu", "violet"
        };

        Afficher(couleurs);
        Console.WriteLine();

        #region Boucle d'initialisation
        var couleursMaj = new string[couleurs.Length];

        for (int i = 0; i < couleurs.Length; i++)
        {
            couleursMaj[i] = couleurs[i].ToUpper();
        }
        #endregion

    }
}
