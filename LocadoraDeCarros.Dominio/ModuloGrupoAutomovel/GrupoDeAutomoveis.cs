using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;

public class GrupoDeAutomoveis : EntidadeBase
{
    public string Nome { get; set; }
    
    public GrupoDeAutomoveis() {}

    public GrupoDeAutomoveis(string nome)
    {
        Nome = nome;
    }

    
    
    #region ImplementarDepois
    // public ICollection<Automovel> Automoveis { get; set; } 
    //
    // public ICollection<PlanoCobranca> PlanosCobranca { get; set; }
    //
    //
    // public GrupoAutomovel()
    // {
    //     Automoveis = new List<Automovel>();
    //     PlanosCobranca = new List<PlanoCobranca>();
    // }
    #endregion
}
