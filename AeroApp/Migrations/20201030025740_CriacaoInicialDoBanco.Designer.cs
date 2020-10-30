﻿// <auto-generated />
using System;
using AeroApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AeroApp.Migrations
{
    [DbContext(typeof(AeroContext))]
    [Migration("20201030025740_CriacaoInicialDoBanco")]
    partial class CriacaoInicialDoBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AeroApp.Model.Local", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("AeroApp.Model.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Documento")
                        .HasColumnType("text");

                    b.Property<int>("Poltrona")
                        .HasColumnType("integer");

                    b.Property<int>("VooId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VooId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("AeroApp.Model.Voo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataIda")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataVolta")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LocalDestinoId")
                        .HasColumnType("integer");

                    b.Property<int>("LocalOrigemId")
                        .HasColumnType("integer");

                    b.Property<int>("NumeroParadas")
                        .HasColumnType("integer");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.Property<TimeSpan>("TempoIda")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("TempoVolta")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("LocalDestinoId");

                    b.HasIndex("LocalOrigemId");

                    b.ToTable("Voos");
                });

            modelBuilder.Entity("AeroApp.Model.Reserva", b =>
                {
                    b.HasOne("AeroApp.Model.Voo", "Voo")
                        .WithMany()
                        .HasForeignKey("VooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AeroApp.Model.Voo", b =>
                {
                    b.HasOne("AeroApp.Model.Local", "LocalDestino")
                        .WithMany()
                        .HasForeignKey("LocalDestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AeroApp.Model.Local", "LocalOrigem")
                        .WithMany()
                        .HasForeignKey("LocalOrigemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}