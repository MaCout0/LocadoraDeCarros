using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.ModuloAutomovel;

public class RepositorioAutomovelEmOrm: RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
{
    public RepositorioAutomovelEmOrm(LocadoraDbContext dbContext) : base(dbContext) { }

    protected override DbSet<Automovel> ObterRegistros()
    {
        return DbContext.Automoveis;
    }
    
    public override Automovel? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(v => v.GrupoAutomoveis)
            .FirstOrDefault(v => v.Id == id);
    }

    public override List<Automovel> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(v => v.GrupoAutomoveis)
            .ToList();
    }
}