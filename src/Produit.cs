using System;

namespace Validation;

class Produit
{
	public required string Ref { get; set; }

	public required string Nom { get; set; }

	public string? Description { get; set; }

	public required double Prix { get; set; }

	public string? CourrielSupport { get; set; }

	public string? PageProduit { get; set; }

	public DateTime Retrait { get; set; }
}
