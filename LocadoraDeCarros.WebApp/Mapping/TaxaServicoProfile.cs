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
        CreateMap<TaxaServico, ListarTaxaServicoViewModel>();
        CreateMap<TaxaServico, DetalhesTaxaServicoViewModel>();
        CreateMap<TaxaServico, EditarTaxaServicoViewModel>();
    }
}