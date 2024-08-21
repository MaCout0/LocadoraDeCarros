using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;

public class MapeadorGrupoDeAutomoveisEmOrm : IEntityTypeConfiguration<GrupoDeAutomoveis>
{
    public void Configure(EntityTypeBuilder<GrupoDeAutomoveis> builder)
    {
        builder.ToTable("TBGrupoDeAutomoveis");
        
        builder.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");
    }
    
    private GrupoDeAutomoveis[] ObterRegistrosPadrao()
    {
        return
        [
            new GrupoDeAutomoveis() { Id = 1, Nome = "Utilitario" },
            new GrupoDeAutomoveis() { Id = 2, Nome = "Esportivo" },
            new GrupoDeAutomoveis() { Id = 3, Nome = "Econômico" },
            new GrupoDeAutomoveis() { Id = 4, Nome = "Luxo" },
            new GrupoDeAutomoveis() { Id = 5, Nome = "Sedan" },
            new GrupoDeAutomoveis() { Id = 6, Nome = "SUV" }
        ];
    }
}