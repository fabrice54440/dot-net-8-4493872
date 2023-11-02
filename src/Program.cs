using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Json;

class Program
{
    static void Main(string[] args)
    {
        // écriture
        var obj = new
        {
            chaine = "toto",
            tableau = new object?[] { null, 3.2, true }
        };
        Console.WriteLine(JsonSerializer.Serialize(obj));

        using (MemoryStream mem = new())
        {
            JsonWriterOptions options = new()
            {
                Indented = true
            };
            using (Utf8JsonWriter writer = new(mem, options))
            {
                writer.WriteStartObject();
                {
                    writer.WriteCommentValue($" Généré par {Assembly.GetCallingAssembly().FullName} ");
                    writer.WriteNumber("nombre-valeurs", 3);
                    writer.WriteStartArray("valeurs");
                    {
                        writer.WriteNumberValue(25.2);
                        writer.WriteStringValue("titi");
                        writer.WriteNullValue();
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndObject();
            }
            Console.WriteLine(Encoding.UTF8.GetString(mem.ToArray()));
        }

        // lecture
        var inconnu = JsonDocument.Parse("""
            {
                "nombre-valeurs": 3,
                "valeurs": [ 25.2, "titi", null ]
            }
            """);

        if (inconnu.RootElement.TryGetProperty("nombre-valeurs", out var a))
        {
            Console.WriteLine($"Lu dans 'nombre-valeurs' : {inconnu}");
        }
        Console.WriteLine("Contenu de 'valeurs'");
        foreach (var val in inconnu.RootElement.GetProperty("valeurs").EnumerateArray())
        {
            Console.WriteLine($"- {val} ({val.ValueKind})");
        }
    }
}
