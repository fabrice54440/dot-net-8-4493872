using System.Diagnostics.CodeAnalysis;

public class Produit
{
    private string _ref = string.Empty;
    private decimal _prix;

    [SetsRequiredMembers]
    public Produit(string Ref, string Nom, decimal Prix = 0.0m)
    {
        this.Ref = Ref;
        this.Nom = Nom;
        this.Prix = Prix;
    }
    public string Ref
    {
        [MemberNotNull(nameof(_ref))]
        private set
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Le paramètre value est vide ou nul.", nameof(value)); 
            }
            _ref = value;
        }
        get => _ref;
    }
    public required string Nom { get; init; }
    public decimal Prix
    {
        get => _prix;
        set
        {
            if(value is <0 or >1_000_000)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            _prix = value;
        }
    }
}