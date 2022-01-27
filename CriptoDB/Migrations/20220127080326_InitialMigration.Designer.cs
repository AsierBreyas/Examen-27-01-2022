﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CriptoDB.Migrations
{
    [DbContext(typeof(CryptoContext))]
    [Migration("20220127080326_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Cripto.Models.Cartera", b =>
                {
                    b.Property<int>("CarteraId")
                        .HasColumnType("int");

                    b.Property<string>("Exchange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarteraId");

                    b.ToTable("Cartera");
                });

            modelBuilder.Entity("Cripto.Models.Contrato", b =>
                {
                    b.Property<int>("CarteraId")
                        .HasColumnType("int");

                    b.Property<string>("MonedaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.HasKey("CarteraId", "MonedaId");

                    b.HasIndex("MonedaId");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("Cripto.Models.Moneda", b =>
                {
                    b.Property<string>("MonedaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Actual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Maximo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MonedaId");

                    b.ToTable("Moneda");
                });

            modelBuilder.Entity("Cripto.Models.Contrato", b =>
                {
                    b.HasOne("Cripto.Models.Cartera", "Cartera")
                        .WithMany("Contratos")
                        .HasForeignKey("CarteraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cripto.Models.Moneda", "Moneda")
                        .WithMany("Contratos")
                        .HasForeignKey("MonedaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartera");

                    b.Navigation("Moneda");
                });

            modelBuilder.Entity("Cripto.Models.Cartera", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Cripto.Models.Moneda", b =>
                {
                    b.Navigation("Contratos");
                });
#pragma warning restore 612, 618
        }
    }
}
