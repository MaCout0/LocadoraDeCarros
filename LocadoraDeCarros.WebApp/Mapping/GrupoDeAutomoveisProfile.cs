using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class GrupoDeAutomoveisProfile : Profile
{
    public GrupoDeAutomoveisProfile()
    {
        CreateMap<InserirGrupoAutomovelViewModel, GrupoDeAutomoveis>();
        CreateMap<EditarGrupoAutomovelViewModel, GrupoDeAutomoveis>();
        CreateMap<GrupoDeAutomoveis, ListarGrupoAutomovelViewModel>();
        CreateMap<GrupoDeAutomoveis, DetalhesGrupoAutomovelViewModel>();
        CreateMap<GrupoDeAutomoveis, EditarGrupoAutomovelViewModel>();
    }
}