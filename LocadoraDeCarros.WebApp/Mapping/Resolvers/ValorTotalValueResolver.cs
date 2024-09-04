using AutoMapper;
using LocadoraDeCarros.Aplicação.ModuloAutomovel;
using LocadoraDeCarros.Aplicação.ModuloPlanoCobranca;
using LocadoraDeCarros.Dominio.ModuloLocacao;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping.Resolvers;

public class ValorTotalValueResolver : IValueResolver<Locacao, ConfirmarDevolucaoLocacaoViewModel, decimal>
{
    private readonly ServicoAutomovel servicoAutomovel;
    private readonly ServicoPlanoCobranca servicoPlano;

    public ValorTotalValueResolver(ServicoAutomovel servicoAutomovel, ServicoPlanoCobranca servicoPlano)
    {
        this.servicoAutomovel = servicoAutomovel;
        this.servicoPlano = servicoPlano;
    }

    public decimal Resolve(
        Locacao source,
        ConfirmarDevolucaoLocacaoViewModel destination,
        decimal destMember,
        ResolutionContext context
    )
    {
        var veiculo = servicoAutomovel.SelecionarPorId(source.AutomovelId).Value;

        var planoSelecionado = servicoPlano.SelecionarPorIdGrupoVeiculos(veiculo.GrupoDeAutomoveisId).Value;

        return source.CalcularValorTotal(planoSelecionado);
    }
}