using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;

namespace LocadoraDeCarros.Dominio.PlanoCobranca;

public class PlanoCobranca : EntidadeBase
{
    public int GrupoAutomoveisId { get; set; }
    public GrupoDeAutomoveis? GrupoDeAutomoveis { get; set; }

    public decimal PrecoDiarioPlanoDiario { get; set; }
    public decimal PrecoQuilometroPlanoDiario { get; set; }

    public decimal QuilometrosDisponiveisPlanoControlado { get; set; }
    public decimal PrecoDiarioPlanoControlado { get; set; }
    public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }

    public decimal PrecoDiarioPlanoLivre { get; set; }

    protected PlanoCobranca() { }

    public PlanoCobranca(
        int grupoAutomoveisId, 
        decimal precoDiarioPlanoDiario, 
        decimal precoQuilometroPlanoDiario, 
        decimal quilometrosDisponiveisPlanoControlado,
        decimal precoDiarioPlanoControlado, 
        decimal precoQuilometroExtrapoladoPlanoControlado, 
        decimal precoDiarioPlanoLivre)
    {
        GrupoAutomoveisId = grupoAutomoveisId;
        PrecoDiarioPlanoDiario = precoDiarioPlanoDiario;
        PrecoQuilometroPlanoDiario = precoQuilometroPlanoDiario;
        QuilometrosDisponiveisPlanoControlado = quilometrosDisponiveisPlanoControlado;
        PrecoDiarioPlanoControlado = precoDiarioPlanoControlado;
        PrecoQuilometroExtrapoladoPlanoControlado = precoQuilometroExtrapoladoPlanoControlado;
        PrecoDiarioPlanoLivre = precoDiarioPlanoLivre;
    }


    public override List<string> Validar()
    {
        List<string> erros = [];

        if (GrupoAutomoveisId == 0)
            erros.Add("O grupo de veículos é obrigatório");

        return erros;
    }
}