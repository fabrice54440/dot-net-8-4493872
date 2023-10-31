using System;
using System.ComponentModel.DataAnnotations;

namespace Validation;

class Produit
{
	[Required(ErrorMessage = "Requis")]
	[RegularExpression("[A-Z0-9]{5,10}", ErrorMessage = "De 5 à 10 lettres majuscules ou chiffres")]
	public required string Ref { get; set; }

	[Required(ErrorMessage = "Requis")]
	[StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Longueur requise : entre {2} et {1} caractères")]
	public required string Nom { get; set; }

	[MaxLength(200, ErrorMessage = "Pas plus de {1} caractères")]
	public string? Description { get; set; }

	[Required(ErrorMessage = "Requis")]
	[Range(minimum: 0.0, maximum: 10000.0, ErrorMessage = "Doit être compris entre {1:0.00} € et {2:0.00} €")]
	public required double Prix { get; set; }

	[EmailAddress(ErrorMessage = "Doit être un courriel valide")]
	public string? CourrielSupport { get; set; }

	[Url(ErrorMessage = "Doit être un lien valide")]
	public string? PageProduit { get; set; }

	//[CustomValidation()]
	public DateTime Retrait { get; set; }
}
