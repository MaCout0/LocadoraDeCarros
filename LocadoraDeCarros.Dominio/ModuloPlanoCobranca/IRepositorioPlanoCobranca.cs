using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloPlanoCobranca;

public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
{
    PlanoCobranca? FiltrarPlano(Func<PlanoCobranca, bool> predicate);
}