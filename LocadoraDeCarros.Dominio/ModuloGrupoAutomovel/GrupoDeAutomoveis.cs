using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuoAutomovel;

namespace LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;

public class GrupoDeAutomoveis : EntidadeBase
{
    protected GrupoDeAutomoveis() {}
    public GrupoDeAutomoveis(string nome)
    {
        Nome = nome;
    }
    
    public string Nome { get; set; }
    public List<Automovel> Automoveis { get; set; } = [];

    
    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Nome.Length < 3)
            erros.Add("O nome é obrigatório");

        return erros;
    }
}
