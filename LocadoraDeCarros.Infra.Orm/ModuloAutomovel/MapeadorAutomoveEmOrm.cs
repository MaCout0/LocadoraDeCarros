using LocadoraDeCarros.Dominio.ModuoAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.Orm.ModuloAutomovel;

public class MapeadorAutomoveEmOrm: IEntityTypeConfiguration<Automovel>
{
    public void Configure(EntityTypeBuilder<Automovel> builder)
    {
        builder.ToTable("TBAutomovel");

        builder.Property(e => e.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.Placa)
            .HasColumnType("varchar(10)")
            .IsRequired();

        builder.Property(e => e.Marca)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(e => e.Cor)
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder.Property(e => e.Modelo)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(e => e.TipoCombustivel)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(e => e.Ano)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(e => e.Grupo)
            .WithMany()
            .HasForeignKey("GrupoId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}