namespace Email;

// Ajouter dans launch.json :
// , "env": {
//     "SMTP_USER": "",
//     "SMTP_PASS": "",
//     "SMTP_HOST": "",
//     "SMTP_PORT": "",
//     "SMTP_SSL": "true"/"false"
// }
class Program
{
    static void Main(string[] args)
    {
        var conf = "USER,PASS,HOST,PORT,SSL".Split(',').ToDictionary(
            p => p, p => Environment.GetEnvironmentVariable($"SMTP_{p}")
        );

    }
}
