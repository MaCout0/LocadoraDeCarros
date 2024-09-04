﻿using LocadoraDeCarros.Dominio.ModuloLocacao;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.ModuloLocacao;

public class RepositorioLocacaoEmOrm : RepositorioBaseEmOrm<Locacao>, IRepositorioLocacao
{
    public RepositorioLocacaoEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Locacao> ObterRegistros()
    {
        return DbContext.Locacoes;
    }

    public override Locacao? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(l => l.Condutor)
            .Include(l => l.Automovel)
            .Include(l => l.ConfiguracaoCombustivel)
            .Include(l => l.TaxasSelecionadas)
            .FirstOrDefault(l => l.Id == id);
    }

    public override List<Locacao> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(l => l.Condutor)
            .Include(l => l.Automovel)
            .Include(l => l.ConfiguracaoCombustivel)
            .ToList();
    }
}