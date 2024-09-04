using Microsoft.AspNetCore.Identity;

namespace LocadoraDeCarros.Dominio.ModuloAutenticacao;

public class Usuario : IdentityUser<int>
{
    public int? EmpresaId { get; set; }
    public Usuario? Empresa { get; set; }

    public Usuario()
    {
        EmailConfirmed = true;
    }
}