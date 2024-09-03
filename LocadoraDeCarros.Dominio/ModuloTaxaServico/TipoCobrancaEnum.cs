using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.Dominio.ModuloTaxaServico;

public enum TipoCobrancaEnum
{
    [Display(Name = "Diária")]
    Diaria,
    Fixa
}