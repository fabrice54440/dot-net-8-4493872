using System.Collections.Generic;
using System.IO;

namespace TypeDyn;

public class Csv
{
  private List<Ligne> lignes = new();

  public Csv(TextReader source, char sep = ';')
  {
    var champs = source.ReadLine()?.Split(sep) ?? Array.Empty<string>();
    string? ligne;

    while ((ligne = source.ReadLine()) != null)
    {
      var dico = new Dictionary<string, string>();
      var valeurs = ligne.Split(sep);

      for (int i = 0; i < Math.Min(champs.Length, ligne.Length); i++)
      {
        dico.Add(champs[i], valeurs[i]);
      }
      lignes.Add(new Ligne(dico));
    }
  }

  public IEnumerable<Csv.Ligne> Lignes => lignes;

  public class Ligne
  {
    private IDictionary<string, string> valeurs;

    public Ligne(IDictionary<string, string> valeurs) => this.valeurs = valeurs;

    public string this[string nom] => valeurs[nom];
  }
}