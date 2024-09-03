using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class CondutorProfile : Profile
{
    public CondutorProfile()
    {
        CreateMap<FormularioCondutorViewModel, Condutor>();

        CreateMap<Condutor, ListarCondutorViewModel>()
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(c => c.Cliente!.Nome))
            .ForMember(dest => dest.ValidadeCNH, opt => opt.MapFrom(c => c.ValidadeCNH.ToShortDateString()));

        CreateMap<Condutor, DetalhesCondutorViewModel>()
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(c => c.Cliente!.Nome))
            .ForMember(dest => dest.ValidadeCNH, opt => opt.MapFrom(c => c.ValidadeCNH.ToShortDateString()));
    }
}