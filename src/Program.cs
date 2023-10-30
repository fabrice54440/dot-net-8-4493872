namespace Entites;

class Program
{
    static void Main(string[] args)
    {
        var p0 = new Produit("A000");
        var p1 = p0;

        p1.Prix *= 1.1m;
        Console.WriteLine("p0 : {0:.00}", p0.Prix);
    }

    public class Produit
    {
        public Produit(string Ref)
        {
            this.Ref = Ref;
        }
        public Produit(string Ref, string Nom, decimal Prix)
        {
            this.Ref = Ref;
            this.Nom = Nom;
            this.Prix = Prix;
        }
        public Produit(string Ref, string Nom) : this(Ref, Nom, 0.0m)
        {
        }

        public string Ref { get; private set; }
        public string Nom { get; init; }
        public decimal Prix { get; set; }
    }
}
