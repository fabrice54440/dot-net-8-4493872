using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Com02;

// Lancer le serveur web dans un terminal
// dotnet run --project src/Com02_web
class Program
{
    static async Task Main(string[] args)
    {
        using MultipartFormDataContent formulaire = new();
        using FileStream flux = new("profil.jpg", FileMode.Open);
        using StreamContent photo = new(flux);

        photo.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

        formulaire.Add(new StringContent("Le chat"), "titre");
        formulaire.Add(photo, "photo", Path.GetFileName(flux.Name));

        using HttpClient http = new() { BaseAddress = new Uri("http://localhost:5000") };
        var réponse = await http.PostAsync($"/", formulaire);

        réponse.EnsureSuccessStatusCode();

        var contenu = await réponse.Content.ReadAsStringAsync();

        Console.WriteLine(contenu);
    }
}
