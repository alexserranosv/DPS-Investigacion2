﻿// <auto-generated />
using System;
using FootballTournamentAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootballTournamentAPI.Migrations
{
    [DbContext(typeof(TorneoFutbolContext))]
    partial class TorneoFutbolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FootballTournamentAPI.Model.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("FootballTournamentAPI.Model.Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Posicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("FootballTournamentAPI.Model.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EquipoLocalId")
                        .HasColumnType("int");

                    b.Property<int>("EquipoVisitanteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EquipoLocalId");

                    b.HasIndex("EquipoVisitanteId");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("FootballTournamentAPI.Model.Resultado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GolesLocal")
                        .HasColumnType("int");

                    b.Property<int>("GolesVisitante")
                        .HasColumnType("int");

                    b.Property<int>("PartidoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId")
                        .IsUnique();

                    b.ToTable("Resultados");
                });

            modelBuilder.Entity("FootballTournamentAPI.Model.Jugador", b =>
                {
                    b.HasOne("FootballTournamentAPI.Model.Equipo", "Equipo")
                        .WithMany("Jugadores")
                        .HasForeignKey("EquipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("FootballTournamentAPI.Model.Partido", b =>
                {
                    b.HasOne("FootballTournamentAPI.Model.Equipo", "EquipoLocal")
                        .WithMany()
                        .HasForeignKey("EquipoLocalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FootballTournamentAPI.Model.Equipo", "EquipoVisitante")
                        .WithMany()
                        .HasForeignKey("EquipoVisitanteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EquipoLocal");

                    b.Navigation("EquipoVisitante");
                });

            modelBuilder.Entity("FootballTournamentAPI.Model.Resultado", b =>
                {
                    b.HasOne("FootballTournamentAPI.Model.Partido", "Partido")
                        .WithOne("Resultado")
                        .HasForeignKey("FootballTournamentAPI.Model.Resultado", "PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partido");
                });

            modelBuilder.Entity("FootballTournamentAPI.Model.Equipo", b =>
                {
                    b.Navigation("Jugadores");
                });

            modelBuilder.Entity("FootballTournamentAPI.Model.Partido", b =>
                {
                    b.Navigation("Resultado")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
