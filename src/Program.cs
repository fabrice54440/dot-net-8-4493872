using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Api;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient http = new() { BaseAddress = new Uri("https://petstore.swagger.io/v2/") };

        var vendus = http.GetFromJsonAsync<IEnumerable<Pet>>("pet/findByStatus?status=sold"); // Animaux vendus
        var disponibles = http.GetFromJsonAsync<IEnumerable<Pet>>("pet/findByStatus?status=available"); // Animaux disponibles

        foreach (var p in (await vendus)!.Union((await disponibles)!))
        {
            Console.WriteLine(p);
        }
    }

    public record Pet(long Id, string Name, string[] PhotoUrls, string Status);
}
