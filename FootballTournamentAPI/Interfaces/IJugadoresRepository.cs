using FootballTournamentAPI.Model;

namespace FootballTournamentAPI.Interfaces
{
    public interface IJugadoresRepository
    {
        Task<IEnumerable<Jugador>> GetAllJugadoresAsync();
        Task<Jugador> GetJugadorByIdAsync(int id);
        Task<IEnumerable<Jugador>> GetJugadoresByEquipoIdAsync(int equipoId);
        Task<Jugador> CreateJugadorAsync(Jugador jugador);
        Task UpdateJugadorAsync(Jugador jugador);
        Task DeleteJugadorAsync(int id);
        Task<bool> JugadorExistsAsync(int id);
    }
}
