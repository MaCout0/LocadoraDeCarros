﻿using LocadoraDeCarros.Dominio.Combustivel;
using LocadoraDeCarros.Infra.Orm.Compartilhado;

namespace LocadoraDeCarros.Infra.Orm.ModuloCombustivel;

public class RepositorioConfiguracaoCombustivelEmOrm : IRepositorioConfiguracaoCombustivel
{
    private readonly LocadoraDbContext dbContext;

    public RepositorioConfiguracaoCombustivelEmOrm(LocadoraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void GravarConfiguracao(ConfiguracaoCombustivel configuracaoCombustivel)
    {
        dbContext.ConfiguracoesCombustiveis.Add(configuracaoCombustivel);

        dbContext.SaveChanges();
    }

    public ConfiguracaoCombustivel? ObterConfiguracao()
    {
        return dbContext.ConfiguracoesCombustiveis
            .OrderByDescending(c => c.Id)
            .FirstOrDefault();
    }
}