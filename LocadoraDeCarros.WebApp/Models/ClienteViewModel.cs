using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.WebApp.Models;

public class FormularioClienteViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório")]
    [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve conter exatamente 11 dígitos")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório")]
    [MinLength(5, ErrorMessage = "O endereço deve conter ao menos 5 caracteres")]
    public string Endereco { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    [Phone(ErrorMessage = "O telefone deve ser válido")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "O email deve ser válido")]
    public string Email { get; set; }
}

public class InserirClienteViewModel : FormularioClienteViewModel { }

public class EditarClienteViewModel : FormularioClienteViewModel
{
    public int Id { get; set; }
}

public class ListarClienteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}

public class DetalhesClienteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}