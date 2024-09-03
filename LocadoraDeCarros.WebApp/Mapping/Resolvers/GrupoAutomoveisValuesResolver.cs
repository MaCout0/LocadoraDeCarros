using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Mapping.Resolvers;

public class GrupoAutomoveisValuesResolver:
    IValueResolver<object, object, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioGrupoDeAutomovel repositorioGrupo;

    public GrupoAutomoveisValuesResolver(IRepositorioGrupoDeAutomovel repositorioGrupo)
    {
        this.repositorioGrupo = repositorioGrupo;
    }

    public IEnumerable<SelectListItem> Resolve(
        object source,
        object destination,
        IEnumerable<SelectListItem>? destMember,
        ResolutionContext context
    )
    {
        return repositorioGrupo
            .SelecionarTodos()
            .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));
    }
}