using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.Orm.ModuloTaxaServico;

public class MapeadorTaxaServicoEmOrm: IEntityTypeConfiguration<TaxaServico>
{
    public void Configure(EntityTypeBuilder<TaxaServico> builder)
    {
        builder.ToTable("TBTaxaServico");

        builder.Property(t => t.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(t => t.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(t => t.Descricao)
            .HasColumnType("varchar(250)")
            .IsRequired();

        builder.Property(t => t.Valor)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(t => t.TipoDeCobranca)
            .HasColumnType("int")
            .IsRequired();
    }
}