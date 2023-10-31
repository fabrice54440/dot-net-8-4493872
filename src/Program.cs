namespace Validation;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Produit p = new()
        {
            Ref = "",
            Nom = "Tong",
            Description = null,
            Prix = -2.3,
            PageProduit = "https://site.example/AM123",
            CourrielSupport = "supportsite.example",
            Retrait = DateTime.Now
        };
        try
        {
            ValidationContext validationProduit = new(p);

            Validator.ValidateObject(p, validationProduit);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }
}
