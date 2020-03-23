﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaVotacionAutomatizada.Models;

namespace SistemaVotacionAutomatizada.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SistemaVotacionAutomatizada.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SistemaVotacionAutomatizada.Models.Candidatos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnName("apellido")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool?>("Estado")
                        .HasColumnName("estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<int?>("PartidoId")
                        .HasColumnName("PartidoID");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnName("photo")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<int?>("PuestoElectivosId")
                        .HasColumnName("Puesto_electivosID");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.HasIndex("PuestoElectivosId");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("SistemaVotacionAutomatizada.Models.Ciudadanos", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("Apellido")
                        .HasColumnName("apellido")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool?>("Estado")
                        .HasColumnName("estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Ciudadanos");
                });

            modelBuilder.Entity("SistemaVotacionAutomatizada.Models.Elecciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Estado")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("fecha")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasMaxLength(40)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Elecciones");
                });

            modelBuilder.Entity("SistemaVotacionAutomatizada.Models.Partidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnName("descripcion")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool?>("Estado")
                        .HasColumnName("estado");

                    b.Property<string>("Logo")
                        .HasColumnName("logo")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasMaxLength(40)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("SistemaVotacionAutomatizada.Models.PuestoElectivos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("descripcion")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool?>("Estado")
                        .HasColumnName("estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasMaxLength(40)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Puesto_electivos");
                });

            modelBuilder.Entity("SistemaVotacionAutomatizada.Models.VotosElecciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidatoId")
                        .HasColumnName("CandidatoID");

                    b.Property<string>("CiudadanoId")
                        .HasColumnName("CiudadanoID")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<int?>("EleccionId")
                        .HasColumnName("EleccionID");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("CiudadanoId");

                    b.HasIndex("EleccionId");

                    b.ToTable("VotosElecciones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SistemaVotacionAutomatizada.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SistemaVotacionAutomatizada.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaVotacionAutomatizada.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SistemaVotacionAutomatizada.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaVotacionAutomatizada.Models.Candidatos", b =>
                {
                    b.HasOne("SistemaVotacionAutomatizada.Models.Partidos", "Partido")
                        .WithMany("Candidatos")
                        .HasForeignKey("PartidoId")
                        .HasConstraintName("FK__Candidato__Parti__70DDC3D8");

                    b.HasOne("SistemaVotacionAutomatizada.Models.PuestoElectivos", "PuestoElectivos")
                        .WithMany("Candidatos")
                        .HasForeignKey("PuestoElectivosId")
                        .HasConstraintName("FK__Candidato__Puest__71D1E811");
                });

            modelBuilder.Entity("SistemaVotacionAutomatizada.Models.VotosElecciones", b =>
                {
                    b.HasOne("SistemaVotacionAutomatizada.Models.Candidatos", "Candidato")
                        .WithMany("VotosElecciones")
                        .HasForeignKey("CandidatoId")
                        .HasConstraintName("FK__VotosElec__Candi__7F2BE32F");

                    b.HasOne("SistemaVotacionAutomatizada.Models.Ciudadanos", "Ciudadano")
                        .WithMany("VotosElecciones")
                        .HasForeignKey("CiudadanoId")
                        .HasConstraintName("FK__VotosElec__Ciuda__00200768");

                    b.HasOne("SistemaVotacionAutomatizada.Models.Elecciones", "Eleccion")
                        .WithMany("VotosElecciones")
                        .HasForeignKey("EleccionId")
                        .HasConstraintName("FK__VotosElec__Elecc__7E37BEF6");
                });
#pragma warning restore 612, 618
        }
    }
}
