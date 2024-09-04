using AutoMapper;
using LocadoraDeCarros.Dominio.Combustivel;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class ConfiguracaoCombustivelProfile : Profile
{
    public ConfiguracaoCombustivelProfile()
    {
        CreateMap<FormularioConfiguracaoCombustivelViewModel, ConfiguracaoCombustivel>();
        CreateMap<ConfiguracaoCombustivel, FormularioConfiguracaoCombustivelViewModel>();
    }
}