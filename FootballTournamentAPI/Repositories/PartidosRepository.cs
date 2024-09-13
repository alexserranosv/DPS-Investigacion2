using FootballTournamentAPI.Interfaces;
using FootballTournamentAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FootballTournamentAPI.Repositories
{
    public class PartidosRepository : IPartidosRepository
    {
        private readonly TorneoFutbolContext _context;

        public PartidosRepository(TorneoFutbolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Partido>> GetAllPartidosAsync()
        {
            return await _context.Partidos
                .Include(p => p.EquipoLocal)
                .Include(p => p.EquipoVisitante)
                .Include(p => p.Resultado)
                .ToListAsync();
        }

        public async Task<Partido> GetPartidoByIdAsync(int id)
        {
            return await _context.Partidos
                .Include(p => p.EquipoLocal)
                .Include(p => p.EquipoVisitante)
                .Include(p => p.Resultado)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Partido>> GetPartidosByEquipoIdAsync(int equipoId)
        {
            return await _context.Partidos
                .Include(p => p.EquipoLocal)
                .Include(p => p.EquipoVisitante)
                .Include(p => p.Resultado)
                .Where(p => p.EquipoLocalId == equipoId || p.EquipoVisitanteId == equipoId)
                .ToListAsync();
        }

        public async Task<Partido> CreatePartidoAsync(Partido partido)
        {
            _context.Partidos.Add(partido);
            await _context.SaveChangesAsync();
            return partido;
        }

        public async Task UpdatePartidoAsync(Partido partido)
        {
            _context.Entry(partido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePartidoAsync(int id)
        {
            var partido = await _context.Partidos.FindAsync(id);
            if (partido != null)
            {
                _context.Partidos.Remove(partido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> PartidoExistsAsync(int id)
        {
            return await _context.Partidos.AnyAsync(p => p.Id == id);
        }
    }
}
