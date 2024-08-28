using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<InserirClienteViewModel, Cliente>();
        CreateMap<EditarClienteViewModel, Cliente>();

        CreateMap<Cliente, ListarClienteViewModel>();
        
        CreateMap<Cliente, DetalhesClienteViewModel>();

        CreateMap<Cliente, EditarClienteViewModel>();
    }

    
}