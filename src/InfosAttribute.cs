namespace Reflexion;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public class InfosAttribute : Attribute
{
  public InfosAttribute(string nom) => Nom = nom;

  public string Nom { get; }
}