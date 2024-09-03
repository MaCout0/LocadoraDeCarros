using System.ComponentModel.DataAnnotations;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Models;

public class FormularioTaxaServicoViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que 0")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "O tipo de cobrança é obrigatório")]
    public TipoCobrancaEnum TipoCobranca { get; set; }

    public IEnumerable<SelectListItem>? TiposCobranca { get; set; }
}

public class InserirTaxaServicoViewModel : FormularioTaxaServicoViewModel
{
}

public class EditarTaxaServicoViewModel : FormularioTaxaServicoViewModel
{
    public int Id { get; set; }
}

public class ListarTaxaServicoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public string TipoCobranca { get; set; }
}

public class DetalhesTaxaServicoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public string TipoCobranca { get; set; }
}
