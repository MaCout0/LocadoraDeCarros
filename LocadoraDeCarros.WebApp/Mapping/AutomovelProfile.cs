using AutoMapper;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.WebApp.Mapping.Resolvers;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class AutomovelProfile: Profile
{
    public AutomovelProfile()
    {
        CreateMap<InserirAutomovelViewModel, Automovel>()
            .ForMember(dest => dest.Foto, opt => opt.MapFrom<FotoValueResolver>());

        CreateMap<EditarAutomovelViewModel, Automovel>()
            .ForMember(dest => dest.Foto, opt => opt.MapFrom<FotoValueResolver>());

        CreateMap<Automovel, ListarAutomovelViewModel>()
            .ForMember(
                dest => dest.GrupoDeAutomoveis,
                opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome)
            );

        CreateMap<Automovel, DetalhesAutomovelViewModel>()
            .ForMember(dest => dest.GrupoDeAutomoveis, opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome));

        CreateMap<Automovel, EditarAutomovelViewModel>()
            .ForMember(v => v.Foto, opt => opt.Ignore())
            .ForMember(v => v.GruposAutomoveis, opt => opt.MapFrom<GrupoAutomoveisValuesResolver>());
    }
}