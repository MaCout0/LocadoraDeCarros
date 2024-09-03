using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class TaxaServicoProfile : Profile
{
    public TaxaServicoProfile()
    {
        CreateMap<InserirTaxaServicoViewModel, TaxaServico>();
        CreateMap<EditarTaxaServicoViewModel, TaxaServico>();

        CreateMap<TaxaServico, ListarTaxaServicoViewModel>()
            .ForMember(
                dest => dest.TipoCobranca,
                opt => opt.MapFrom(x => x.TipoCobranca.ToString())
            );

        CreateMap<TaxaServico, DetalhesTaxaServicoViewModel>()
            .ForMember(
                dest => dest.TipoCobranca,
                opt => opt.MapFrom(x => x.TipoCobranca.ToString())
            );

        CreateMap<TaxaServico, EditarTaxaServicoViewModel>();
    }
}