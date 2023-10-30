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
            ArgumentException.ThrowIfNullOrEmpty(value);
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
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 1_000_000);
            _prix = value;
        }
    }
}