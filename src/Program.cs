using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Net.Mail;

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
        using SmtpClient smtp = new(conf["HOST"], int.Parse(conf["PORT"] ?? "25"))
        {
            Credentials = new NetworkCredential(conf["USER"], conf["PASS"]),
            EnableSsl = conf["SSL"] == "true"
        };

        try
        {
            MailMessage message = new()
            {
                IsBodyHtml = true,
                From = new MailAddress(conf["USER"] ?? "anonyme@example.com", "Inconnu"),
                Subject = "Test",
                Body = """
                    <html>
                        <p>Bonjour,</p>
                        <p>Message bien envoyé avec :
                        <ul><li>Du HTML<li>Une PJ</ul>
                        <p>Merci,</p>
                        <p>Sylvain</p>
                    </html>
                    """
            };
            Attachment pj = new Attachment("obj/Debug/net8.0/Email.pdb");

            message.Attachments.Add(pj);
            message.To.Add(new MailAddress("contact@syllab.com"));
            smtp.Send(message);
            Console.WriteLine("Message envoyé");
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }
}
