namespace Ipc;

class Program
{
    const int EOT = int.MinValue;
#if TEST
    // Compil. dans src : dotnet build /p:DefineConstants="TEST" -o test
    // Codespaces exec : ./test/Ipc
    static void Main(string[] args)
    {
        Span<byte> mem = new(new byte[4]);
        
        // Création / Connexion au canal
        
        tuyau.Connect();
                    
        for(var fib = (n1: 0, n2: 1); fib.n1 < 1000; fib = (fib.n2, fib.n1+fib.n2))
        {
            BitConverter.TryWriteBytes(mem, fib.n1);
            // Envoi de mem dans le canal
        }
        BitConverter.TryWriteBytes(mem, EOT);
        // Envoi de mem dans le canal
        // Fermeture
    }
#else
    // Codespaces exec : dotnet run
    static void Main(string[] args)
    {
        // Création du canal
        byte[] mem = new byte[sizeof(int)];

        // Attente d'une connexion
        for (; ; )
        {
            // Lecture sur le canal
            var val = BitConverter.ToInt32(mem);
            if (val == EOT)
            {
                // Déconnexion
                break;
            }
            Console.WriteLine(val);
        }
    }
#endif
}
