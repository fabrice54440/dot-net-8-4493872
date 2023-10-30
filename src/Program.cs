namespace Exceptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var p0 = new Produit("", "Casserole", 20.50m);
        }
        catch (ArgumentException e) when (e.ParamName == "value")
        {
            Console.Error.WriteLine("Référence : {0}", e.Message);
        }
        catch (ArgumentException e) when (e.ParamName == "Nom")
        {
            Console.Error.WriteLine("Nom : {0}", e.Message);
        }
    }
}
