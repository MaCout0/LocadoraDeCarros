using AutoMapper;
using LocadoraDeCarros.Dominio.PlanoCobranca;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class PlanoCobrancaProfile : Profile
{
    public PlanoCobrancaProfile()
    {
        CreateMap<InserirPlanoCobrancaViewModel, PlanoCobranca>();
        CreateMap<EditarPlanoCobrancaViewModel, PlanoCobranca>();

        CreateMap<PlanoCobranca, ListarPlanoCobrancaViewModel>()
            .ForMember(
                dest => dest.GrupoAutomoveis,
                opt => opt.MapFrom(src => src.GrupoDeAutomoveis!.Nome));

        CreateMap<PlanoCobranca, DetalhesPlanoCobrancaViewModel>()
            .ForMember(
                dest => dest.GrupoAutomoveis,
                opt => opt.MapFrom(src => src.GrupoDeAutomoveis!.Nome));

        CreateMap<PlanoCobranca, EditarPlanoCobrancaViewModel>();
    }
}