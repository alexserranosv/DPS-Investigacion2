using FootballTournamentAPI.Interfaces;
using FootballTournamentAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FootballTournamentAPI.Repositories
{
    public class EquiposRepository : IEquiposRepository
    {
        private readonly TorneoFutbolContext _context;

        public EquiposRepository(TorneoFutbolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipo>> GetAllEquiposAsync()
        {
            return await _context.Equipos.ToListAsync();
        }

        public async Task<Equipo> GetEquipoByIdAsync(int id)
        {
            return await _context.Equipos.FindAsync(id);
        }

        public async Task<Equipo> CreateEquipoAsync(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return equipo;
        }

        public async Task UpdateEquipoAsync(Equipo equipo)
        {
            _context.Entry(equipo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEquipoAsync(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipos.Remove(equipo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EquipoExistsAsync(int id)
        {
            return await _context.Equipos.AnyAsync(e => e.Id == id);
        }
    }
}
