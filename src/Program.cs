namespace Reflexion;

class Program
{
    static void Main(string[] args)
    {
        Produit p = new("Tongs", 2.30m);

        Console.WriteLine(p.GetType().Assembly);
        Console.WriteLine(p.GetType().Name);

        foreach (var prop in typeof(Produit).GetProperties())
        {
            var infos = prop.GetCustomAttributes(typeof(InfosAttribute), false) as InfosAttribute[] ?? Array.Empty<InfosAttribute>();

            Console.Write(infos.Length > 0 ? infos[0].Nom : prop.Name);
            Console.Write(" : ");
            Console.WriteLine(prop.GetGetMethod()?.Invoke(p, Array.Empty<object>()));
        }
    }
}
[Infos("C'est un produit")]
public record Produit(string Nom, decimal Prix)
{
    [Infos("Le prix TTC")]
    public decimal PrixTTC => Prix * 1.2m;
}