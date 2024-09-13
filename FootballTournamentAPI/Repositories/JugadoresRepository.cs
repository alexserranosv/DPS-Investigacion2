using FootballTournamentAPI.Interfaces;
using FootballTournamentAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FootballTournamentAPI.Repositories
{
    public class JugadoresRepository : IJugadoresRepository
    {
        private readonly TorneoFutbolContext _context;

        public JugadoresRepository(TorneoFutbolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Jugador>> GetAllJugadoresAsync()
        {
            return await _context.Jugadores.Include(j => j.Equipo).ToListAsync();
        }

        public async Task<Jugador> GetJugadorByIdAsync(int id)
        {
            return await _context.Jugadores
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<IEnumerable<Jugador>> GetJugadoresByEquipoIdAsync(int equipoId)
        {
            return await _context.Jugadores
                .Where(j => j.EquipoId == equipoId)
                .ToListAsync();
        }

        public async Task<Jugador> CreateJugadorAsync(Jugador jugador)
        {
            _context.Jugadores.Add(jugador);
            await _context.SaveChangesAsync();
            return jugador;
        }

        public async Task UpdateJugadorAsync(Jugador jugador)
        {
            _context.Entry(jugador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJugadorAsync(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugadores.Remove(jugador);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> JugadorExistsAsync(int id)
        {
            return await _context.Jugadores.AnyAsync(j => j.Id == id);
        }
    }
}
