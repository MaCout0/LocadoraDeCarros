using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.ModuloTaxaServico;

public class RepositorioTaxaServicoEmOrm : RepositorioBaseEmOrm<TaxaServico>, IRepositorioTaxaServico
{
    public RepositorioTaxaServicoEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<TaxaServico> ObterRegistros()
    {
        return _dbContext.TaxaServicos;
    }
}