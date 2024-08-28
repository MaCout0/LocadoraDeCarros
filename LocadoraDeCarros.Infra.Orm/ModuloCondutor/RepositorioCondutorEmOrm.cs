using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Infra.Orm.Compartilhado;

using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.ModuloCondutor;

public class RepositorioCondutorEmOrm : RepositorioBaseEmOrm<Condutor>, IRepositorioCondutor
{
    public RepositorioCondutorEmOrm(LocadoraDbContext dbContext) : base(dbContext) {}

    protected override DbSet<Condutor> ObterRegistros()
    {
        return DbContext.Condutores;
    }
    
    public override Condutor? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(v => v.Clientes)
            .FirstOrDefault(v => v.Id == id);
    }

    public override List<Condutor> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(v => v.Clientes)
            .ToList();
    }
}