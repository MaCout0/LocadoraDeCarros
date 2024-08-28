using LocadoraDeCarros.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.Compartilhado;

public abstract class RepositorioBaseEmOrm<TEntidade> where TEntidade: EntidadeBase
{
    protected readonly LocadoraDbContext DbContext;

    protected RepositorioBaseEmOrm(LocadoraDbContext dbContext)
    {
        this.DbContext = dbContext;
    }

    protected abstract DbSet<TEntidade> ObterRegistros();

    public void Inserir(TEntidade entidade)
    {
        ObterRegistros().Add(entidade);

        DbContext.SaveChanges();
    }

    public void Editar(TEntidade entidade)
    {
        ObterRegistros().Update(entidade);

        DbContext.SaveChanges();
    }
    
    public void Excluir(TEntidade entidade)
    {
        ObterRegistros().Remove(entidade);

        DbContext.SaveChanges();
    }
    
    public virtual TEntidade? SelecionarPorId(int id)
    {
        return ObterRegistros().FirstOrDefault(r => r.Id == id);
    }

    public virtual List<TEntidade> SelecionarTodos()
    {
        return ObterRegistros()
            .ToList();
    }
}