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
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(e => e.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();
    }
    
    
}