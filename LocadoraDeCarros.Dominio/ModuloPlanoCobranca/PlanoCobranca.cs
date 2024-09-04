using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuloLocacao;

namespace LocadoraDeCarros.Dominio.ModuloPlanoCobranca;

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
    
    public decimal CalcularValor(int quantidadeDeDias, int quilometragemPercorrida, TipoPlanoCobrancaEnum tipoPlano)
    {
        decimal valor = 0.0m;

        switch (tipoPlano)
        {
            case TipoPlanoCobrancaEnum.Diario:
                decimal valorDiasPlanoDiario = quantidadeDeDias * PrecoDiarioPlanoDiario;

                decimal valorQuilometragemPercorridaPlanoDiario =
                    quilometragemPercorrida * PrecoQuilometroPlanoDiario;

                valor = valorDiasPlanoDiario + valorQuilometragemPercorridaPlanoDiario;
                break;

            case TipoPlanoCobrancaEnum.Controlado:
                decimal valorDiasPlanoControlado = quantidadeDeDias * PrecoDiarioPlanoControlado;

                decimal quilometrosExtrapolados =
                    quilometragemPercorrida - QuilometrosDisponiveisPlanoControlado;

                decimal valorQuilometragemPlanoControlado =
                    quilometrosExtrapolados * PrecoQuilometroExtrapoladoPlanoControlado;

                valor = valorDiasPlanoControlado;

                if (quilometrosExtrapolados > 0) valor += valorQuilometragemPlanoControlado;
                break;

            case TipoPlanoCobrancaEnum.Livre:
                valor = quantidadeDeDias * PrecoDiarioPlanoDiario;
                break;
        }

        return valor;
    }
}