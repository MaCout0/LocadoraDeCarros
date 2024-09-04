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
        return DbContext.TaxaServicos;
    }

    public List<TaxaServico> SelecionarMuitos(List<int> idsTaxasSelecionadas)
    {
        return DbContext.TaxaServicos
            .Where(taxa => idsTaxasSelecionadas.Contains(taxa.Id))
            .ToList();
    }
}