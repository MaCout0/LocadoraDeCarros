using LocadoraDeCarros.Dominio.PlanoCobranca;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.ModuloPlanoCobranca;

public class RepositorioPlanoCobrancaEmOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanoCobranca
{
    public RepositorioPlanoCobrancaEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<PlanoCobranca> ObterRegistros()
    {
        return DbContext.PlanosCobranca;
    }

    public override PlanoCobranca? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(p => p.GrupoDeAutomoveis)
            .FirstOrDefault(p => p.Id == id);
    }

    public override List<PlanoCobranca> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(p => p.GrupoDeAutomoveis)
            .AsNoTracking()
            .ToList();
    }
}
