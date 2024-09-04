using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.Dominio.ModuloAutenticacao;

public enum TipoUsuarioEnum
{
    Empresa,
    [Display(Name = "Funcionário")] Funcionario
}