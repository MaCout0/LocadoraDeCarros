using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.ModuloAutomovel;

public class RepositorioAutomovelEmOrm: RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
{
    public RepositorioAutomovelEmOrm(LocadoraDbContext dbContext) : base(dbContext) { }

    protected override DbSet<Automovel> ObterRegistros()
    {
        return _dbContext.Automoveis;
    }
}