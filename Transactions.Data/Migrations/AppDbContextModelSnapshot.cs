﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Transactions.Data;

#nullable disable

namespace Transactions.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Transactions.Data.Entities.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Contraseña");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PersonaId")
                        .IsUnique();

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Transactions.Data.Entities.Cuenta", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuentaId"), 1L, 1);

                    b.Property<bool>("Habilitada")
                        .HasColumnType("bit");

                    b.Property<int>("PropiedadCuentaId")
                        .HasColumnType("int");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoCuentaId")
                        .HasColumnType("int");

                    b.HasKey("CuentaId");

                    b.HasIndex("PropiedadCuentaId");

                    b.HasIndex("TipoCuentaId");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Transactions.Data.Entities.CuentasClientes", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClienteId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<int>("CuentasClientesId")
                        .HasColumnType("int");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("CuentasClientes");
                });

            modelBuilder.Entity("Transactions.Data.Entities.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            GeneroId = 1,
                            Nombre = "Femenino"
                        },
                        new
                        {
                            GeneroId = 2,
                            Nombre = "Maculino"
                        });
                });

            modelBuilder.Entity("Transactions.Data.Entities.Movimientos", b =>
                {
                    b.Property<int>("MovimientosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovimientosId"), 1L, 1);

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Habilitada")
                        .HasColumnType("bit");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoMovimientoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MovimientosId");

                    b.HasIndex("CuentaId");

                    b.HasIndex("TipoMovimientoId");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("Transactions.Data.Entities.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonaId"), 1L, 1);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<bool>("Habilitada")
                        .HasColumnType("bit");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonaId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Transactions.Data.Entities.PropiedadCuenta", b =>
                {
                    b.Property<int>("PropiedadCuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropiedadCuentaId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PropiedadCuentaId");

                    b.ToTable("PropiedadCuentas");

                    b.HasData(
                        new
                        {
                            PropiedadCuentaId = 1,
                            Nombre = "Abonable"
                        },
                        new
                        {
                            PropiedadCuentaId = 2,
                            Nombre = "Crediticia"
                        });
                });

            modelBuilder.Entity("Transactions.Data.Entities.TipoCuenta", b =>
                {
                    b.Property<int>("TipoCuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoCuentaId"), 1L, 1);

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoCuentaId");

                    b.ToTable("TiposDeCuentas");

                    b.HasData(
                        new
                        {
                            TipoCuentaId = 1,
                            Habilitado = true,
                            Nombre = "Ahorro"
                        },
                        new
                        {
                            TipoCuentaId = 2,
                            Habilitado = true,
                            Nombre = "Corriente"
                        });
                });

            modelBuilder.Entity("Transactions.Data.Entities.TipoMovimientos", b =>
                {
                    b.Property<int>("TipoMovimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoMovimientoId"), 1L, 1);

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("TipoMovimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoMovimientoId");

                    b.ToTable("TipoDeMovimientos");

                    b.HasData(
                        new
                        {
                            TipoMovimientoId = 1,
                            Habilitado = true,
                            TipoMovimiento = "Abono"
                        },
                        new
                        {
                            TipoMovimientoId = 2,
                            Habilitado = true,
                            TipoMovimiento = "Debito"
                        });
                });

            modelBuilder.Entity("Transactions.Data.Entities.TipoSolicitudMovimiento", b =>
                {
                    b.Property<int>("TipoSolicitudMovimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoSolicitudMovimientoId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoSolicitudMovimientoId");

                    b.ToTable("TipoSolicitudMovimientos");

                    b.HasData(
                        new
                        {
                            TipoSolicitudMovimientoId = 1,
                            Nombre = "Abono"
                        },
                        new
                        {
                            TipoSolicitudMovimientoId = 2,
                            Nombre = "Debito"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Transactions.Data.Entities.Cliente", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Transactions.Data.Entities.Cliente", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Transactions.Data.Entities.Cliente", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Transactions.Data.Entities.Cliente", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Transactions.Data.Entities.Cliente", b =>
                {
                    b.HasOne("Transactions.Data.Entities.Persona", "Persona")
                        .WithOne("Cliente")
                        .HasForeignKey("Transactions.Data.Entities.Cliente", "PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Transactions.Data.Entities.Cuenta", b =>
                {
                    b.HasOne("Transactions.Data.Entities.PropiedadCuenta", "PropiedadCuenta")
                        .WithMany("Cuentas")
                        .HasForeignKey("PropiedadCuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Transactions.Data.Entities.TipoCuenta", "TipoCuenta")
                        .WithMany("Cuentas")
                        .HasForeignKey("TipoCuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PropiedadCuenta");

                    b.Navigation("TipoCuenta");
                });

            modelBuilder.Entity("Transactions.Data.Entities.CuentasClientes", b =>
                {
                    b.HasOne("Transactions.Data.Entities.Cuenta", "Cuenta")
                        .WithMany("CuentasClientes")
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Transactions.Data.Entities.Cliente", "Cliente")
                        .WithMany("CuentasClientes")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("Transactions.Data.Entities.Movimientos", b =>
                {
                    b.HasOne("Transactions.Data.Entities.Cuenta", "Cuenta")
                        .WithMany("Movimientos")
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Transactions.Data.Entities.TipoMovimientos", "TipoMovimiento")
                        .WithMany("Movimientos")
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");

                    b.Navigation("TipoMovimiento");
                });

            modelBuilder.Entity("Transactions.Data.Entities.Persona", b =>
                {
                    b.HasOne("Transactions.Data.Entities.Genero", "Genero")
                        .WithMany("Personas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("Transactions.Data.Entities.Cliente", b =>
                {
                    b.Navigation("CuentasClientes");
                });

            modelBuilder.Entity("Transactions.Data.Entities.Cuenta", b =>
                {
                    b.Navigation("CuentasClientes");

                    b.Navigation("Movimientos");
                });

            modelBuilder.Entity("Transactions.Data.Entities.Genero", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Transactions.Data.Entities.Persona", b =>
                {
                    b.Navigation("Cliente")
                        .IsRequired();
                });

            modelBuilder.Entity("Transactions.Data.Entities.PropiedadCuenta", b =>
                {
                    b.Navigation("Cuentas");
                });

            modelBuilder.Entity("Transactions.Data.Entities.TipoCuenta", b =>
                {
                    b.Navigation("Cuentas");
                });

            modelBuilder.Entity("Transactions.Data.Entities.TipoMovimientos", b =>
                {
                    b.Navigation("Movimientos");
                });
#pragma warning restore 612, 618
        }
    }
}
