using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.Dominio.ModuloLocacao;

public enum TipoPlanoCobrancaEnum
{
    [Display(Name = "Diário")] Diario,
    Controlado,
    Livre
}