using FootballTournamentAPI.Model;

namespace FootballTournamentAPI.Interfaces
{
    public interface IPartidosRepository
    {
        Task<IEnumerable<Partido>> GetAllPartidosAsync();
        Task<Partido> GetPartidoByIdAsync(int id);
        Task<IEnumerable<Partido>> GetPartidosByEquipoIdAsync(int equipoId);
        Task<Partido> CreatePartidoAsync(Partido partido);
        Task UpdatePartidoAsync(Partido partido);
        Task DeletePartidoAsync(int id);
        Task<bool> PartidoExistsAsync(int id);
    }
}
