using Microsoft.EntityFrameworkCore;

namespace FootballTournamentAPI.Model
{
    public class TorneoFutbolContext : DbContext
    {
        public TorneoFutbolContext(DbContextOptions<TorneoFutbolContext> options)
            : base(options)
        {
        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Resultado> Resultados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partido>()
                .HasOne(p => p.EquipoLocal)
                .WithMany()
                .HasForeignKey(p => p.EquipoLocalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Partido>()
                .HasOne(p => p.EquipoVisitante)
                .WithMany()
                .HasForeignKey(p => p.EquipoVisitanteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resultado>()
                .HasOne(r => r.Partido)
                .WithOne(p => p.Resultado)
                .HasForeignKey<Resultado>(r => r.PartidoId);
        }
    }
}
