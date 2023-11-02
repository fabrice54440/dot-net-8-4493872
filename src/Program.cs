using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Chiffrement;

class Program
{
    static void Main(string[] args)
    {
        // Symétrique
        string key, iv;

        using (var aes = Aes.Create())
        {
            key = Convert.ToBase64String(aes.Key);
            iv = Convert.ToBase64String(aes.IV);
            using (FileStream f = new("obj/fichier.sec", FileMode.Create))
            using (var transform = aes.CreateEncryptor())
            using (CryptoStream dest = new(f, transform, CryptoStreamMode.Write))
            using (StreamWriter writer = new(dest))
            {
                writer.WriteLine("Le roi est nu");
            }
        }

        using (var aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);
            using (FileStream f = new("obj/fichier.sec", FileMode.Open))
            using (var transform = aes.CreateDecryptor())
            using (CryptoStream source = new(f, transform, CryptoStreamMode.Read))
            using (StreamReader reader = new(source))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        // Asymétrique
        var message = Encoding.ASCII.GetBytes("Le roi est nu");
        byte[] chiffré;

        using (RSACryptoServiceProvider rsaDest = new())
        {
            var cléPublique = rsaDest.ToXmlString(includePrivateParameters: false);

            using (RSACryptoServiceProvider rsaEnvoi = new())
            {
                rsaEnvoi.FromXmlString(cléPublique);
                chiffré = rsaEnvoi.Encrypt(message, false);
            }

            var octets = rsaDest.Decrypt(chiffré, false);
            Console.WriteLine(Encoding.ASCII.GetString(octets));
        }
    }
}
