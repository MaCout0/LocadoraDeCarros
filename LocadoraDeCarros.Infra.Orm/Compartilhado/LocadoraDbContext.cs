using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Dominio.PlanoCobranca;
using LocadoraDeCarros.Infra.Orm.ModuloAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloCliente;
using LocadoraDeCarros.Infra.Orm.ModuloCondutor;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeCarros.Infra.Orm.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeCarros.Infra.Orm.Compartilhado;

public class LocadoraDbContext : DbContext
{
    public DbSet<GrupoDeAutomoveis> GrupoAutomoveis { get; set; }
    public DbSet<Automovel> Automoveis { get; set; }
    public DbSet<PlanoCobranca> PlanosCobranca { get; set; }
    public DbSet<TaxaServico> TaxaServicos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Condutor> Condutores { get; set; }
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
            modelBuilder.ApplyConfiguration(new MapeadorTaxaServicoEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorClienteEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorCondutorEmOrm());
            
            base.OnModelCreating(modelBuilder);
        }
}