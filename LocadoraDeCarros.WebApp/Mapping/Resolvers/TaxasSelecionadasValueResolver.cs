using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloLocacao;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping.Resolvers;

public class TaxasSelecionadasValueResolver : IValueResolver<FormularioLocacaoViewModel, Locacao, List<TaxaServico>>
{
    private readonly IRepositorioTaxaServico repositorioTaxa;

    public TaxasSelecionadasValueResolver(IRepositorioTaxaServico repositorioTaxa)
    {
        this.repositorioTaxa = repositorioTaxa;
    }

    public List<TaxaServico> Resolve(
        FormularioLocacaoViewModel source,
        Locacao destination,
        List<TaxaServico> destMember,
        ResolutionContext context
    )
    {
        var idsTaxasSelecionadas = source.TaxasSelecionadas.ToList();

        return repositorioTaxa.SelecionarMuitos(idsTaxasSelecionadas);
    }
}