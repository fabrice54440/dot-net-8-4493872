using System.Net.Http;

namespace Api;

class Program
{
    static void Main(string[] args)
    {
        using HttpClient http = new() { BaseAddress = new Uri("https://petstore.swagger.io/v2/") };

        // Animaux vendus
        var vendus = http.GetAsync("pet/findByStatus?status=sold");

        Console.WriteLine(vendus.Result.Content.ReadAsStringAsync().Result);

        // Animaux disponibles
        var disponibles = http.GetAsync("pet/findByStatus?status=available");

        Console.WriteLine(disponibles.Result.Content.ReadAsStringAsync().Result);
    }
}
