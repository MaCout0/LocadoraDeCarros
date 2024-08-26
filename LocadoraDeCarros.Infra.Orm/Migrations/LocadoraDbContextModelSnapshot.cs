﻿// <auto-generated />
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraDeCarros.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraDbContext))]
    partial class LocadoraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel.GrupoDeAutomoveis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoDeAutomoveis", (string)null);
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuoAutomovel.Automovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CapacidadeTanque")
                        .HasColumnType("int");

                    b.Property<int>("GrupoDeAutomoveisId")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoDeAutomoveisId");

                    b.ToTable("TBAutomovel", (string)null);
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.PlanoCobranca.PlanoCobranca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GrupoAutomoveisId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoDiarioPlanoControlado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoDiarioPlanoDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoDiarioPlanoLivre")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoQuilometroExtrapoladoPlanoControlado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoQuilometroPlanoDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuilometrosDisponiveisPlanoControlado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoAutomoveisId");

                    b.ToTable("TBPlanoCobranca", (string)null);
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuoAutomovel.Automovel", b =>
                {
                    b.HasOne("LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel.GrupoDeAutomoveis", "GrupoAutomoveis")
                        .WithMany("Automoveis")
                        .HasForeignKey("GrupoDeAutomoveisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GrupoAutomoveis");
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.PlanoCobranca.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel.GrupoDeAutomoveis", "GrupoDeAutomoveis")
                        .WithMany()
                        .HasForeignKey("GrupoAutomoveisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GrupoDeAutomoveis");
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel.GrupoDeAutomoveis", b =>
                {
                    b.Navigation("Automoveis");
                });
#pragma warning restore 612, 618
        }
    }
}
