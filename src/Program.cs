namespace Reflexion;

class Program
  {
    static void Main(string[] args)
    {
      Produit p = new("Tongs", 2.30m);

      foreach (var prop in typeof(Produit).GetProperties())
      {
        Console.WriteLine(prop.Name);
      }
    }
  }
  public record Produit(string Nom, decimal Prix)
  {
    public decimal PrixTTC => Prix * 1.2m;
  }