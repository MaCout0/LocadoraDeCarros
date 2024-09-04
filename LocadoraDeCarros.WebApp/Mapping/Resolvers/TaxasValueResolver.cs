using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloLocacao;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Mapping.Resolvers;

public class TaxasValueResolver : IValueResolver<Locacao, FormularioLocacaoViewModel, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioTaxaServico repositorioTaxa;

    public TaxasValueResolver(IRepositorioTaxaServico repositorioTaxa)
    {
        this.repositorioTaxa = repositorioTaxa;
    }

    public IEnumerable<SelectListItem>? Resolve(Locacao source, FormularioLocacaoViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {

        return repositorioTaxa
            .SelecionarTodos()
            .Select(t => new SelectListItem(t.ToString(), t.Id.ToString()));
    }
}