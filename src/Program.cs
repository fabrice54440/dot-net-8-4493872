namespace Exceptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var p0 = new Produit("", "Casserole", 20.50m);
        }
        catch (ArgumentException e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }
}
