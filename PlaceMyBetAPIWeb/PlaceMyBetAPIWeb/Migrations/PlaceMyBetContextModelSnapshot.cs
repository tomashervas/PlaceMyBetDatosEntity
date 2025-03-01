﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaceMyBetAPIWeb.Models;

namespace PlaceMyBetAPIWeb.Migrations
{
    [DbContext(typeof(PlaceMyBetContext))]
    partial class PlaceMyBetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PlaceMyBetAPIWeb.Models.Apuesta", b =>
                {
                    b.Property<int>("apuestaID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("cuota");

                    b.Property<double>("dinero");

                    b.Property<string>("mercado");

                    b.Property<int>("mercadoID");

                    b.Property<string>("tipo");

                    b.Property<int>("usuarioID");

                    b.HasKey("apuestaID");

                    b.HasIndex("mercadoID");

                    b.HasIndex("usuarioID");

                    b.ToTable("Apuestas");

                    b.HasData(
                        new
                        {
                            apuestaID = 1,
                            cuota = 1.8999999999999999,
                            dinero = 20.0,
                            mercado = "1.5",
                            mercadoID = 1,
                            tipo = "under",
                            usuarioID = 1
                        },
                        new
                        {
                            apuestaID = 2,
                            cuota = 1.8999999999999999,
                            dinero = 10.0,
                            mercado = "1.5",
                            mercadoID = 1,
                            tipo = "over",
                            usuarioID = 2
                        });
                });

            modelBuilder.Entity("PlaceMyBetAPIWeb.Models.Cuenta", b =>
                {
                    b.Property<int>("cuentaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("banco");

                    b.Property<double>("saldo");

                    b.Property<string>("tarjeta");

                    b.Property<int>("usuarioID");

                    b.HasKey("cuentaID");

                    b.HasIndex("usuarioID")
                        .IsUnique();

                    b.ToTable("Cuentas");

                    b.HasData(
                        new
                        {
                            cuentaID = 1,
                            banco = "Bankia",
                            saldo = 200.0,
                            tarjeta = "2222222222222222",
                            usuarioID = 1
                        },
                        new
                        {
                            cuentaID = 2,
                            banco = "Savadell",
                            saldo = 200.0,
                            tarjeta = "333333333333333",
                            usuarioID = 2
                        });
                });

            modelBuilder.Entity("PlaceMyBetAPIWeb.Models.Evento", b =>
                {
                    b.Property<int>("eventoID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("fechaHoraEvento");

                    b.Property<string>("local");

                    b.Property<string>("visitante");

                    b.HasKey("eventoID");

                    b.ToTable("Eventos");

                    b.HasData(
                        new
                        {
                            eventoID = 1,
                            fechaHoraEvento = new DateTime(2019, 11, 6, 0, 32, 12, 657, DateTimeKind.Local).AddTicks(4637),
                            local = "Valencia",
                            visitante = "Madrid"
                        },
                        new
                        {
                            eventoID = 2,
                            fechaHoraEvento = new DateTime(2019, 11, 6, 0, 32, 12, 663, DateTimeKind.Local).AddTicks(4491),
                            local = "Barcelona",
                            visitante = "Betis"
                        });
                });

            modelBuilder.Entity("PlaceMyBetAPIWeb.Models.Mercado", b =>
                {
                    b.Property<int>("mercadoID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("cuotaOver");

                    b.Property<double>("cuotaUnder");

                    b.Property<double>("dineroOver");

                    b.Property<double>("dineroUnder");

                    b.Property<int>("eventoID");

                    b.Property<string>("mercado");

                    b.HasKey("mercadoID");

                    b.HasIndex("eventoID");

                    b.ToTable("Mercados");

                    b.HasData(
                        new
                        {
                            mercadoID = 1,
                            cuotaOver = 1.8999999999999999,
                            cuotaUnder = 1.8999999999999999,
                            dineroOver = 100.0,
                            dineroUnder = 100.0,
                            eventoID = 1,
                            mercado = "1.5"
                        },
                        new
                        {
                            mercadoID = 2,
                            cuotaOver = 1.8999999999999999,
                            cuotaUnder = 1.8999999999999999,
                            dineroOver = 100.0,
                            dineroUnder = 100.0,
                            eventoID = 1,
                            mercado = "2.5"
                        });
                });

            modelBuilder.Entity("PlaceMyBetAPIWeb.Models.Usuario", b =>
                {
                    b.Property<int>("usuarioID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("apellidos");

                    b.Property<int>("edad");

                    b.Property<string>("email");

                    b.Property<string>("nombre");

                    b.Property<double>("saldo");

                    b.HasKey("usuarioID");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            usuarioID = 1,
                            apellidos = "Garcia",
                            edad = 34,
                            email = "pepegarcia@gmail.com",
                            nombre = "Pepe",
                            saldo = 200.0
                        },
                        new
                        {
                            usuarioID = 2,
                            apellidos = "Sanchez",
                            edad = 25,
                            email = "rosasanchez@gmail.com",
                            nombre = "Rosa",
                            saldo = 300.0
                        });
                });

            modelBuilder.Entity("PlaceMyBetAPIWeb.Models.Apuesta", b =>
                {
                    b.HasOne("PlaceMyBetAPIWeb.Models.Mercado", "Mercado")
                        .WithMany("Apuesta")
                        .HasForeignKey("mercadoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PlaceMyBetAPIWeb.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("usuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PlaceMyBetAPIWeb.Models.Cuenta", b =>
                {
                    b.HasOne("PlaceMyBetAPIWeb.Models.Usuario", "Usuario")
                        .WithOne("Cuenta")
                        .HasForeignKey("PlaceMyBetAPIWeb.Models.Cuenta", "usuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PlaceMyBetAPIWeb.Models.Mercado", b =>
                {
                    b.HasOne("PlaceMyBetAPIWeb.Models.Evento", "Evento")
                        .WithMany("Mercados")
                        .HasForeignKey("eventoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
