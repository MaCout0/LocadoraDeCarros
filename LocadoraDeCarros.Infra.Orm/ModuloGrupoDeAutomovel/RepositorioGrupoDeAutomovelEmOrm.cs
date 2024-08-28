using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;

public class RepositorioGrupoDeAutomovelEmOrm : RepositorioBaseEmOrm<GrupoDeAutomoveis> , IRepositorioGrupoDeAutomovel
{
    public RepositorioGrupoDeAutomovelEmOrm(LocadoraDbContext dbContext) : base(dbContext) { }
   

    protected override DbSet<GrupoDeAutomoveis> ObterRegistros()
    {
        return DbContext.GrupoAutomoveis;
    }
}