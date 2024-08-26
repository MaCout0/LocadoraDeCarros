﻿using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Dominio.PlanoCobranca;
using LocadoraDeCarros.Infra.Orm.ModuloAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeCarros.Infra.Orm.Compartilhado;

public class LocadoraDbContext : DbContext
{
    public DbSet<GrupoDeAutomoveis> GrupoAutomoveis { get; set; }
    public DbSet<Automovel> Automoveis { get; set; }
    public DbSet<PlanoCobranca> PlanosCobranca { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config
            .GetConnectionString("SqlServer");

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorGrupoDeAutomoveisEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorAutomoveEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorPlanoCobrancaEmOrm());
            
            base.OnModelCreating(modelBuilder);
        }
}