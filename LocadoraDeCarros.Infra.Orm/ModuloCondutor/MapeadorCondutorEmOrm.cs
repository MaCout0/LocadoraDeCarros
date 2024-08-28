using LocadoraDeCarros.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.Orm.ModuloCondutor;

public class MapeadorCondutorEmOrm : IEntityTypeConfiguration<Condutor>
{
    public void Configure(EntityTypeBuilder<Condutor> builder)
    {
        builder.ToTable("TBCondutor");
            
        builder.Property(e => e.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();
            
        builder.Property(e => e.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();
            
        builder.Property(e => e.CPF)
            .HasColumnType("varchar(11)")
            .IsRequired();
            
        builder.Property(e => e.CNH)
            .HasColumnType("varchar(20)")
            .IsRequired();
            
        builder.Property(e => e.ValidadeCNH)
            .HasColumnType("date")
            .IsRequired();
            
        builder.Property(e => e.Telefone)
            .HasColumnType("varchar(15)")
            .IsRequired();
    }
}
