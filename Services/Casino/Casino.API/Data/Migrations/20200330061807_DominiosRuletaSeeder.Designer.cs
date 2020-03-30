﻿// <auto-generated />
using System;
using Casino.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Casino.API.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200330061807_DominiosRuletaSeeder")]
    partial class DominiosRuletaSeeder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Casino.API.Data.Entities.Dominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("PadreId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PadreId");

                    b.ToTable("Dominios");
                });

            modelBuilder.Entity("Casino.API.Data.Entities.Ruleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<long>("UsuarioRegistraIdId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("TipoId");

                    b.HasIndex("UsuarioRegistraIdId");

                    b.ToTable("Ruletas");
                });

            modelBuilder.Entity("Casino.API.Data.Entities.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CloudIdentityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Casino.API.Data.Entities.Dominio", b =>
                {
                    b.HasOne("Casino.API.Data.Entities.Dominio", "Padre")
                        .WithMany()
                        .HasForeignKey("PadreId");
                });

            modelBuilder.Entity("Casino.API.Data.Entities.Ruleta", b =>
                {
                    b.HasOne("Casino.API.Data.Entities.Dominio", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Casino.API.Data.Entities.Dominio", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Casino.API.Data.Entities.Usuario", "UsuarioRegistraId")
                        .WithMany()
                        .HasForeignKey("UsuarioRegistraIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}