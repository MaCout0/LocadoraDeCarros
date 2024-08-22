using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.WebApp.Models;

public class InserirGrupoAutomovelViewModel
{
    [Required(ErrorMessage = "O Nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
    public string Nome { get; set; }
}

public class EditarGrupoAutomovelViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O Nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
    public string Nome { get; set; }
}

public class ListarGrupoAutomovelViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class DetalhesGrupoAutomovelViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

