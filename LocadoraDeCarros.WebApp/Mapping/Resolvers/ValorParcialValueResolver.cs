using AutoMapper;
using LocadoraDeCarros.Aplicação.ModuloAutomovel;
using LocadoraDeCarros.Aplicação.ModuloPlanoCobranca;
using LocadoraDeCarros.Dominio.ModuloLocacao;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping.Resolvers;

public class ValorParcialValueResolver : IValueResolver<Locacao, ConfirmarAberturaLocacaoViewModel, decimal>
{
    private readonly ServicoAutomovel servicoVeiculo;
    private readonly ServicoPlanoCobranca servicoPlano;

    public ValorParcialValueResolver(ServicoAutomovel servicoVeiculo, ServicoPlanoCobranca servicoPlano)
    {
        this.servicoVeiculo = servicoVeiculo;
        this.servicoPlano = servicoPlano;
    }

    public decimal Resolve(
        Locacao source,
        ConfirmarAberturaLocacaoViewModel destination,
        decimal destMember,
        ResolutionContext context
    )
    {
        var veiculo = servicoVeiculo.SelecionarPorId(source.AutomovelId).Value;

        var planoSelecionado = servicoPlano.SelecionarPorIdGrupoVeiculos(veiculo.GrupoDeAutomoveisId).Value;

        return source.CalcularValorParcial(planoSelecionado);
    }
}