using AutoMapper;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class AutomovelProfile: Profile
{
    public AutomovelProfile()
    {
        CreateMap<InserirAutomovelViewModel, Automovel>();
        CreateMap<EditarAutomovelViewModel, Automovel>();

        CreateMap<Automovel, ListarAutomovelViewModel>()
            .ForMember(
                dest => dest.GrupoDeAutomoveis,
                opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome)
            );

        CreateMap<Automovel, DetalhesAutomovelViewModel>()
            .ForMember(
                dest => dest.GrupoDeAutomoveis,
                opt => opt.MapFrom(src => src.GrupoAutomoveis!.Nome)
            );

        CreateMap<Automovel, EditarAutomovelViewModel>();
    }
}