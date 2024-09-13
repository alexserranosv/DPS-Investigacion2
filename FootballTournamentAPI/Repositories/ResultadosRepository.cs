using FootballTournamentAPI.Interfaces;
using FootballTournamentAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FootballTournamentAPI.Repositories
{
    public class ResultadosRepository : IResultadosRepository
    {
        private readonly TorneoFutbolContext _context;

        public ResultadosRepository(TorneoFutbolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resultado>> GetAllResultadosAsync()
        {
            return await _context.Resultados
                .Include(r => r.Partido)
                    .ThenInclude(p => p.EquipoLocal)
                .Include(r => r.Partido)
                    .ThenInclude(p => p.EquipoVisitante)
                .ToListAsync();
        }

        public async Task<Resultado> GetResultadoByIdAsync(int id)
        {
            return await _context.Resultados
                .Include(r => r.Partido)
                    .ThenInclude(p => p.EquipoLocal)
                .Include(r => r.Partido)
                    .ThenInclude(p => p.EquipoVisitante)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Resultado> GetResultadoByPartidoIdAsync(int partidoId)
        {
            return await _context.Resultados
                .Include(r => r.Partido)
                    .ThenInclude(p => p.EquipoLocal)
                .Include(r => r.Partido)
                    .ThenInclude(p => p.EquipoVisitante)
                .FirstOrDefaultAsync(r => r.PartidoId == partidoId);
        }

        public async Task<Resultado> CreateResultadoAsync(Resultado resultado)
        {
            _context.Resultados.Add(resultado);
            await _context.SaveChangesAsync();
            return resultado;
        }

        public async Task UpdateResultadoAsync(Resultado resultado)
        {
            _context.Entry(resultado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResultadoAsync(int id)
        {
            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado != null)
            {
                _context.Resultados.Remove(resultado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ResultadoExistsAsync(int id)
        {
            return await _context.Resultados.AnyAsync(r => r.Id == id);
        }
    }
}
