using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;

public class RepositorioGrupoDeAutomovelEmOrm : RepositorioBaseEmOrm<GrupoDeAutomoveis> , IRepositorioGrupoDeAutomovel
{
    public RepositorioGrupoDeAutomovelEmOrm(LocadoraDeCarrosDbContext dbContext) : base(dbContext) { }
   

    protected override DbSet<GrupoDeAutomoveis> ObterRegistros()
    {
        return _dbContext.GrupoAutomoveis;
    }

    public List<GrupoDeAutomoveis> Filtrar(Func<GrupoDeAutomoveis, bool> predicate)
    {
        return _dbContext.GrupoAutomoveis
            .Where(predicate)
            .ToList();
    }
}