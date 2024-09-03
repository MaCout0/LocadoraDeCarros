using AutoMapper;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping.Resolvers;

public class FotoValueResolver : IValueResolver<FormularioAutomovelViewModel, Automovel, byte[]>
{
    public FotoValueResolver() { }

    public byte[] Resolve(
        FormularioAutomovelViewModel source,
        Automovel destination,
        byte[] destMember,
        ResolutionContext context
    )
    {
        using (var memoryStream = new MemoryStream())
        {
            source.Foto.CopyTo(memoryStream);

            return memoryStream.ToArray();
        }
    }
}