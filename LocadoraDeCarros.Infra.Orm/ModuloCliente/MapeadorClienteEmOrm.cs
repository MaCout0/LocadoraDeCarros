using LocadoraDeCarros.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.Orm.ModuloCliente
{
    public class MapeadorClienteEmOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBCliente");

            builder.Property(c => c.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(c => c.CPF)
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(c => c.Endereco)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

        }
    }
}